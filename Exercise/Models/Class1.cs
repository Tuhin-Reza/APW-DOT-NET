//using System;
//using System.ComponentModel.DataAnnotations;

//public class UserModelValidation : ValidationAttribute
//{
//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        var userModel = (UserModel)validationContext.ObjectInstance;

//        if (userModel == null)
//        {
//            return ValidationResult.Success;
//        }

//        // Add your validation logic here for each property.
//        if (!IsValidName(userModel.name))
//        {
//            return new ValidationResult("Name must be 4 to 50 characters and can only contain letters, spaces, dots, and dashes.");
//        }

//        if (!IsValidUserID(userModel.user_id))
//        {
//            return new ValidationResult("User ID must start with an alphabet, be 4 to 12 characters, and can only contain letters, numbers, underscores, and dashes.");
//        }

//        if (!IsValidPassword(userModel.password))
//        {
//            return new ValidationResult("Password must meet certain criteria.");
//        }

//        if (!IsValidID(userModel.id))
//        {
//            return new ValidationResult("ID must meet certain criteria.");
//        }

//        if (!IsValidEmail(userModel.email))
//        {
//            return new ValidationResult("Invalid email address format.");
//        }

//        if (!IsValidDOB(userModel.dob))
//        {
//            return new ValidationResult("Invalid date of birth.");
//        }

//        return ValidationResult.Success;
//    }

//    private bool IsValidName(string name)
//    {
//        // Add your name validation logic here.
//        // Return true if valid; otherwise, return false.
//    }

//    private bool IsValidUserID(string user_id)
//    {
//        // Add your user ID validation logic here.
//        // Return true if valid; otherwise, return false.
//    }

//    private bool IsValidPassword(string password)
//    {
//        // Add your password validation logic here.
//        // Return true if valid; otherwise, return false.
//    }

//    private bool IsValidID(string id)
//    {
//        // Add your ID validation logic here.
//        // Return true if valid; otherwise, return false.
//    }

//    private bool IsValidEmail(string email)
//    {
//        // Add your email validation logic here.
//        // Return true if valid; otherwise, return false.
//    }

//    private bool IsValidDOB(DateTime dob)
//    {
//        // Add your date of birth validation logic here.
//        // Return true if valid; otherwise, return false.
//    }
//}
