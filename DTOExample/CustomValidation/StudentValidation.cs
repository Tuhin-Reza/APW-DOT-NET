using System.ComponentModel.DataAnnotations;

namespace DTOExample.CustomValidation
{
    public class NameAttribute : ValidationAttribute
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

    public class CGPAAttribute : ValidationAttribute
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

    public class DeptIDAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int deptID)
            {
                if (deptID > 0)
                {
                    return true; // Valid department ID
                }
            }
            return false; // Invalid department ID
        }
    }

}