using System;
using System.ComponentModel.DataAnnotations;

namespace lab4.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class id_email_Match : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var emailProperty = validationContext.ObjectType.GetProperty("email");
            var idProperty = validationContext.ObjectType.GetProperty("id");

            if (emailProperty == null || idProperty == null)
            {
                return ValidationResult.Success;
            }

            var emailValue = emailProperty.GetValue(validationContext.ObjectInstance) as string;
            var idValue = idProperty.GetValue(validationContext.ObjectInstance) as string;

            if (emailValue == null || idValue == null)
            {
                return ValidationResult.Success;
            }
            string first10Characters = emailValue.Length <= 10 ? emailValue : emailValue.Substring(0, 10);
            if (first10Characters == idValue)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("*email do not match the 'id' property.");
        }
    }
}