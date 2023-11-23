using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ZeroHunger.CustomValidation
{
    public class assignDistributorValidation
    {
        public class nameValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string name)
                {
                    if (!string.IsNullOrEmpty(name) && name.Length >= 3)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Name must be at least 3 characters long.");
                }
                return new ValidationResult("Invalid value for name.");
            }
        }
        public class contactNumberValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string contactNumber)
                {
                    if (!string.IsNullOrEmpty(contactNumber) && Regex.IsMatch(contactNumber, @"^\d{5}-\d{6}$"))
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Contact number must be in the format 12345-123456.");
                }
                return new ValidationResult("Invalid value for contact number.");
            }
        }

        public class emailValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string email)
                {
                    const string emailRegexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
                    if (!string.IsNullOrEmpty(email) && Regex.IsMatch(email, emailRegexPattern))
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Invalid email format.");
                }
                return new ValidationResult("Invalid value for email.");
            }
        }

        public class areaValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string area)
                {
                    if (!string.IsNullOrEmpty(area) && area.Length >= 4)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Area must be at least 4 characters long.");
                }
                return new ValidationResult("Invalid value for area.");
            }
        }

        public class usernameValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string username)
                {
                    const string pattern = @"^[a-zA-Z]{3}.*\d+.*$";

                    if (!string.IsNullOrEmpty(username) && Regex.IsMatch(username, pattern))
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Username must start with 3 letters and include at least one number.");
                }
                return new ValidationResult("Invalid value for username.");
            }
        }

        public class passwordValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string password)
                {
                    if (!string.IsNullOrEmpty(password) && password.Length >= 3)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Password must be at least 4 characters long.");
                }
                return new ValidationResult("Invalid value for password.");
            }
        }

    }
}