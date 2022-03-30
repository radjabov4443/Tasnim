using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasnim.Domain.Entities.Tests;
using Tasnim.Service.Attributes;
using Tasnim.Service.Configurations;

namespace Tasnim.Service.DTOs
{
    public class UserForRegistrationDto
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [EmailAddress]
        [StringLength(50,
           ErrorMessage = "Must be between 5 and 50 characters",
           MinimumLength = 5)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(255,
            ErrorMessage = "Must be between 8 and 255 characters",
            MinimumLength = 8)]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [CheckPhoneNumber]        
        public string PhoneNumber { get; set; }
        public ICollection<Test> TestAnswers { get; set; }
    }
}
