using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ZeroHunger.CustomValidation
{

    public class assignCollectorValidation
    {
        public class NameValidation : ValidationAttribute
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
        public class ContactNumberValidation : ValidationAttribute
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

        public class EmailValidation : ValidationAttribute
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

        public class VehicleTypeValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string vehicleType)
                {
                    if (!string.IsNullOrEmpty(vehicleType) && vehicleType != "---Select Vehicle Type---")
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Please select a valid vehicle type.");
                }
                return new ValidationResult("Invalid value for vehicle type.");
            }
        }


        public class UsernameValidation : ValidationAttribute
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



        public class PasswordValidation : ValidationAttribute
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