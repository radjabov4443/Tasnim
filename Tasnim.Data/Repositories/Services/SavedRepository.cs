using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.SavedContents;

namespace Tasnim.Data.Repositories.Services
{
    public class SavedRepository : GenericRepository<SavedContent>, ISavedRepository
    {
        public SavedRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}