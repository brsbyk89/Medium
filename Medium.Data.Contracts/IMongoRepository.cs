using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Data.Contracts
{
    public interface IMongoRepository<TEntity> where TEntity : class
    {
        Task BulkCreate(IEnumerable<TEntity> obj);
        void InsertMany(IEnumerable<TEntity> obj);
        Task Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
