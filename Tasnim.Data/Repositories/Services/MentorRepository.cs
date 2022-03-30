using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Mentors;

namespace Tasnim.Data.Repositories.Services
{
    public class MentorRepository : GenericRepository<Mentor>, IMentorRepository
    {
        public MentorRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}