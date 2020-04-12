using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medium.Data.Contracts
{
    public interface IMongoBookDBContext
    {
        public IMongoCollection<Book> GetCollection<Book>(string name);
    }
}
