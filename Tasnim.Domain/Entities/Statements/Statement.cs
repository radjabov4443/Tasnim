using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Statements
{
    public class Statement : IAuditable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
