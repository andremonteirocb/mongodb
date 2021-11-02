using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Data.Base;

namespace Fundamentos.NoSQL.Data
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IMongoDBConfig config)
            : base(config)
        {
        }
    }
}