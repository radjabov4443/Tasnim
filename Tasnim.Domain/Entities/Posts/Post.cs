using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Mentors;

namespace Tasnim.Domain.Entities.Posts
{
    public class Post : IAuditable
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        [Required]
        public Mentor Mentor { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public DateTime DeletedDate { get; set; }
    }
}
