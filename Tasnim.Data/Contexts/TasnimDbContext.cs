using Microsoft.EntityFrameworkCore;
using Tasnim.Domain.Entities.Audios;
using Tasnim.Domain.Entities.Books;
using Tasnim.Domain.Entities.Statements;
using Tasnim.Domain.Entities.Trainings;
using Tasnim.Domain.Entities.Users;
using Tasnim.Domain.Entities.Videos;

namespace Tasnim.Data.Contexts
{
    public class TasnimDbContext : DbContext
    {
        public TasnimDbContext(DbContextOptions<TasnimDbContext> options)
            : base(options)
        {
            
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Audio> Audios { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Statement> Statements { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
    }
}
