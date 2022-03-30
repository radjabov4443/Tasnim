using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Videos;

namespace Tasnim.Data.Repositories.Services
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        public VideoRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}