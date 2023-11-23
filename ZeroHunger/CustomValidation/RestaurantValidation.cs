using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ZeroHunger.CustomValidation
{
    public class RestaurantValidation
    {
        public class nameR : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string name && !string.IsNullOrEmpty(name))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Restaurant name is required.");
            }
        }

        public class LocationValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string location && !string.IsNullOrEmpty(location))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Location is required.");
            }
        }

        public class cnameR : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string name && !string.IsNullOrEmpty(name))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Restaurant name is required.");
            }
        }

        public class contactPersonNumberR : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string contactNumber && Regex.IsMatch(contactNumber, @"^\d{5}-\d{6}$"))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Contact number must be in the format 12345-123456.");
            }
        }

        public class emailR : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                const string emailRegexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
                if (value is string email && Regex.IsMatch(email, emailRegexPattern))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Invalid email format.");
            }
        }

        public class usernameR : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                const string pattern = @"^[a-zA-Z]{3}.*\d+.*$";
                if (value is string username && Regex.IsMatch(username, pattern))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Username must start with 3 letters and include at least one number.");
            }
        }

        public class passwordR : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string password && password.Length >= 4)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Password must be at least 4 characters long.");
            }
        }
    }
}