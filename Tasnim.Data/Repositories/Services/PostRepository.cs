using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Posts;

namespace Tasnim.Data.Repositories.Services
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}