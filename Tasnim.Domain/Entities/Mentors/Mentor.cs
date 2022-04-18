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
        public string Image { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public ItemState State { get; set; } = ItemState.Created;
        public Mentor()
        {
            Posts = new List<Post>();
        }
    }
}