using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Test> TestAnswers { get; set; }
        public ICollection<SavedContent> SavedContents { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
        public ItemState State { get; set; } = ItemState.Created;

        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value.Date; }
        }

        public void Delete()
        {
            State = ItemState.Deleted;
        }

        public void Update()
        {
            State = ItemState.Updated;
            UpdatedDate = DateTime.Now;
        }
    }
}
