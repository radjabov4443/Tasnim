using Microsoft.EntityFrameworkCore;
using Tasnim.Domain.Entities.Audios;
using Tasnim.Domain.Entities.Books;
using Tasnim.Domain.Entities.Mentors;
using Tasnim.Domain.Entities.Posts;
using Tasnim.Domain.Entities.SavedContents;
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
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SavedContent> SavedContents { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }

    }
}
