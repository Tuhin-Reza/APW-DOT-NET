using System;
using System.ComponentModel.DataAnnotations;

namespace lab4.Models
{
    public class ageCalculate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                int age = DateTime.Now.Year - date.Year;
                if (age > 18)
                {
                    return true;
                }
            }
            return false;
        }
    }
}