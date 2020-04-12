using Medium.Data.Contracts;
using MongoDB.Driver;
using System;

namespace Medium.Data.Contexts
{
    public class MongoContext : IMongoBookDBContext, IDisposable
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public MongoContext()
        {
            _mongoClient = new MongoClient("Buraya Connection String gelecek");
            _db = _mongoClient.GetDatabase("DatabaseName");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public void Dispose()
        {

        }
    }
}
