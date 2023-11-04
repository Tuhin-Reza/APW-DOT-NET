using System.ComponentModel.DataAnnotations;
namespace Task3.Validation
{
    public class name : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return true;
            }
            return false;
        }
    }
    public class password : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return true;
            }
            return false;
        }
    }
}