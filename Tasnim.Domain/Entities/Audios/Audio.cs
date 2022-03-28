using Tasnim.Domain.Common;

namespace Tasnim.Domain.Entities.Audios
{
    public class Audio : IAuditable
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int MyProperty { get; set; }
    }
}
