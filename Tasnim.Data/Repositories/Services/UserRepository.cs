using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Users;

namespace Tasnim.Data.Repositories.Services
{
#pragma warning disable
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper mapper;
        public UserRepository(TasnimDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
        }
        
        public async Task<User> UpdateAsync(User user)
        {
            var result = dbSet.FirstOrDefault(x => x.Id == user.Id);

            result = mapper.Map(user, result);

            dbContext.Entry(user).State = EntityState.Modified;

            return result;
        }
    }
}
