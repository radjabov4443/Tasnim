using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Shows;

namespace Tasnim.Data.Repositories.Services
{
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        public ShowRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}