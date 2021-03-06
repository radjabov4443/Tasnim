using System.Text.Json.Serialization;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Mentors;

namespace Tasnim.Domain.Entities.Videos
{
    public class Video : IAuditable
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public Mentor Mentor { get; set; }
    }
}
