using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Task3.Validation
{
    public class UserDTOValidation : ValidationAttribute
    {
    }

    public class Name : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            if (value == null)
            {
                ErrorMessage = "*name required";
                return false;
            }

            if (value.ToString().Length < 3)
            {
                ErrorMessage = "*length minimum 3";
                return false;
            }

            if (value.ToString().Contains(" "))
            {
                ErrorMessage = "*White space not allowed";
                return false;
            }

            if (!Regex.IsMatch(value.ToString(), "^[a-z]+[0-9]*$"))
            {
                ErrorMessage = "*only lowercase letters & at least one number";
                return false;
            }
            return true;
        }
    }
}

public class Password : ValidationAttribute
{
    public override bool IsValid(object value)
    {

        if (value == null)
        {
            ErrorMessage = "*password required";
            return false;
        }

        if (value.ToString().Length < 4)
        {
            ErrorMessage = "*length minimum 4";
            return false;
        }

        if (value.ToString().Contains(" "))
        {
            ErrorMessage = "*White space not allowed";
            return false;
        }

        if (!Regex.IsMatch(value.ToString(), "^(?=.*[a-z].*[a-z])(?=.*[0-9])(?=.*\\W).+$"))
        {
            ErrorMessage = "*at least two lowercase letters, one number, and one special character";
            return false;
        }
        return true;
    }
}