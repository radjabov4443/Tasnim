using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Users;

namespace Tasnim.Data.Repositories.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}
