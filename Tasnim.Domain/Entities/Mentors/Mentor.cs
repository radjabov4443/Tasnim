using System;
using System.Collections.Generic;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.Audios;
using Tasnim.Domain.Entities.Posts;
using Tasnim.Domain.Entities.Videos;
using Tasnim.Domain.Enums;

namespace Tasnim.Domain.Entities.Mentors
{
    public class Mentor : IAuditable
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Audio> Audios { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public ItemState State { get; set; } = ItemState.Created;
        public Mentor()
        {
            Posts = new List<Post>();
            Audios = new List<Audio>();
            Videos = new List<Video>();
        }
    }
}