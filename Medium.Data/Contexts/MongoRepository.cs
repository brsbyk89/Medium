using Medium.Data.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Data.Contexts
{
    public abstract class MongoRepository<TEntity, TContext> : IMongoRepository<TEntity> where TEntity : class where TContext : IMongoBookDBContext, new()
    {
        protected readonly IMongoBookDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        protected MongoRepository()
        {
            _mongoContext = new TContext();

            //Entity Class'larının üzerinde ki BsonDiscriminator
            var className = typeof(TEntity).CustomAttributes.Select(p => p.ConstructorArguments[0].Value).FirstOrDefault().ToString();

            _dbCollection = _mongoContext.GetCollection<TEntity>(className);
        }
        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }

            var className = typeof(TEntity).CustomAttributes.Select(p => p.ConstructorArguments[0].Value).FirstOrDefault().ToString();

            _dbCollection = _mongoContext.GetCollection<TEntity>(className);
            await _dbCollection.InsertOneAsync(obj);
        }

        public async Task BulkCreate(IEnumerable<TEntity> obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }

            var className = typeof(TEntity).CustomAttributes.Select(p => p.ConstructorArguments[0].Value).FirstOrDefault().ToString();

            _dbCollection = _mongoContext.GetCollection<TEntity>(className);
            await _dbCollection.InsertManyAsync(obj);
        }

        public void InsertMany(IEnumerable<TEntity> obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }

            var className = typeof(TEntity).CustomAttributes.Select(p => p.ConstructorArguments[0].Value).FirstOrDefault().ToString();

            _dbCollection = _mongoContext.GetCollection<TEntity>(className);
            _dbCollection.InsertMany(obj);
        }

        public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));

        }
        public virtual void Update(TEntity obj)
        {
            //_dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.ObjIdTest), obj);
        }

        public async Task<TEntity> Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            var className = typeof(TEntity).CustomAttributes.Select(p => p.ConstructorArguments[0].Value).FirstOrDefault().ToString();

            _dbCollection = _mongoContext.GetCollection<TEntity>(className);


            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }
    }

}
