using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Audios;
using Tasnim.Domain.Entities.Posts;
using Tasnim.Domain.Entities.Users;
using Tasnim.Domain.Entities.Videos;

namespace Tasnim.Domain.Entities.SavedContents
{
    public class SavedContent : IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public DateTime SavedDate { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual User User { get; set; }
        public SavedContent()
        {
            Posts = new List<Post>();
        }
    }
}