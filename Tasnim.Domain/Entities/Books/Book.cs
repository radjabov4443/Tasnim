using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Books
{
    public class Book : IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
