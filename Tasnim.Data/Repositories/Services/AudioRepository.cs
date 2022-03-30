using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Audios;

namespace Tasnim.Data.Repositories.Services
{
    public class AudioRepository : GenericRepository<Audio>, IAudioRepository
    {
        public AudioRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}