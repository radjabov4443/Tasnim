using Microsoft.EntityFrameworkCore;

namespace Tasnim.Data.Contexts
{
    internal class TasnimDbContext : DbContext
    {
        public TasnimDbContext(DbContextOptions<TasnimDbContext> options) : base(options)
        {
        }
    }
}
