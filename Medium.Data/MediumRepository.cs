using Medium.Business.Entities;
using Medium.Data.Contexts;
using Medium.Data.Contracts;
using System;

namespace Medium.Data
{
    public class MediumRepository : MongoRepository<Story, MongoContext>, IMediumRepository
    {
    }
}
