using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasnim.Domain.Common;
using Tasnim.Domain.Entities.SavedContents;
using Tasnim.Domain.Entities.Tests;
using Tasnim.Domain.Enums;

namespace Tasnim.Domain.Entities.Users
{
    public class User : IAuditable
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Test> TestAnswers { get; set; }
        public ICollection<SavedContent> SavedContents { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ItemState State { get; set; } = ItemState.Created;

        public void Delete()
        {
            State = ItemState.Deleted;
        }
    }
}
