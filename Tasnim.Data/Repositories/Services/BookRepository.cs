using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Domain.Entities.Books;

namespace Tasnim.Data.Repositories.Services
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(TasnimDbContext dbContext) : base(dbContext)
        {
        }
    }
}