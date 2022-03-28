using System;
using System.ComponentModel.DataAnnotations;
using Tasnim.Domain.Common;
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
        public Religion Religion { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
