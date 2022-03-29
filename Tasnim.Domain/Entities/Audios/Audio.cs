using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Audios
{
    public class Audio : IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }      
        public string Title { get; set; }
        public string Length { get; set; }
        public string Path { get; set; }
    }
}
