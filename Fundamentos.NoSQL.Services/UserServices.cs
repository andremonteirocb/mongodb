using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Services
{
    public class UserServices : BaseService<User>, IUserServices
    {
        public UserServices(IUserRepository userRepository)
            : base(userRepository)
        {
        }
    }
}