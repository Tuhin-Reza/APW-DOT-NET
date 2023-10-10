using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Exercise.Models
{
    public class SignupFnameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var signup = (Signup)validationContext.ObjectInstance;

            List<string> errorMessages = ValidateName(signup.fname);
            if (errorMessages.Count > 0)
            {
                return new ValidationResult(string.Join(" ", errorMessages));
            }
            return ValidationResult.Success;
        }

        private List<string> ValidateName(string name)
        {
            List<string> errorMessages = new List<string>();
            if (string.IsNullOrEmpty(name))
            {
                errorMessages.Add("Name cannot be null or empty.");
                return errorMessages; // Return immediately after encountering the null or empty value.
            }
            if (Regex.IsMatch(name, @"\d"))
            {
                errorMessages.Add("Name cannot contain numbers.");
            }
            if (name.Length < 4 || name.Length > 50)
            {
                errorMessages.Add("Name must be between 4 and 50 characters.");
            }
            return errorMessages;
        }
    }
    public class SignuplnameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var signup = (Signup)validationContext.ObjectInstance;
            List<string> errorMessages2 = ValidatelName(signup.lname);
            if (errorMessages2.Count > 0)
            {
                return new ValidationResult(string.Join(" ", errorMessages2));
            }
            return ValidationResult.Success;
        }
        private List<string> ValidatelName(string name)
        {
            List<string> errorMessages2 = new List<string>();
            if (string.IsNullOrEmpty(name))
            {
                errorMessages2.Add("lName cannot be null or empty.");
                return errorMessages2;
            }
            if (Regex.IsMatch(name, @"\d"))
            {
                errorMessages2.Add("LName cannot contain numbers.");
            }
            if (name.Length < 4 || name.Length > 50)
            {
                errorMessages2.Add("LName must be between 4 and 50 characters.");
            }
            return errorMessages2;
        }
    }
}
