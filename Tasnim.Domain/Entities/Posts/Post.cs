using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Audios;
using Tasnim.Domain.Entities.Mentors;
using Tasnim.Domain.Entities.Videos;

namespace Tasnim.Domain.Entities.Posts
{
    public class Post : IAuditable
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        [Required]
        public Mentor Mentor { get; set; }
        public Audio Audio { get; set; }
        public Video Video { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime DeletedDate { get; set; }
    }
}
