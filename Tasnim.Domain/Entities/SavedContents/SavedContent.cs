using System;
using System.Collections.Generic;
using Tasnim.Domain.Entities.Audios;
using Tasnim.Domain.Entities.Posts;
using Tasnim.Domain.Entities.Users;
using Tasnim.Domain.Entities.Videos;

namespace Tasnim.Domain.Entities.SavedContents
{
    public class SavedContent
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedDate { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Audio> Audios { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual User User { get; set; }
        public SavedContent()
        {
            Posts = new List<Post>();
            Audios = new List<Audio>();
            Videos = new List<Video>();
        }
    }
}