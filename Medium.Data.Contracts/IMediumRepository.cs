using Medium.Business.Entities;

namespace Medium.Data.Contracts
{
    public interface IMediumRepository : IMongoRepository<Story>
    {
    }
}
