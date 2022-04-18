using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim.Service.Attributes
{
    public class ImageValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var file = value as IFormFile;
            if (file == null)
            {
                return ValidationResult.Success;
            }
            if (file.Length > 1024 * 1024 * 2)
            {
                return new ValidationResult("Maximum file size is 2MB");
            }
            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                return new ValidationResult("Only jpeg and png files are allowed");
            }
            return ValidationResult.Success;
        }
    }
}
