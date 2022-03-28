using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Videos
{
    public class Video : IAuditable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
