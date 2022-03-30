using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Trainings;

namespace Tasnim.Data.Repositories.Services
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}