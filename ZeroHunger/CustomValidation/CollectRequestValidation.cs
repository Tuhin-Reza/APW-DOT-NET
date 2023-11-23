using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.CustomValidation
{
    public class CollectRequestValidation
    {
        public class DateTimeValoidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateTimeValue)
                {
                    if (dateTimeValue >= DateTime.Now)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("The date and time must not be in the past.");
                }
                return new ValidationResult("Invalid date and time.");
            }

            public class TimeValidation : ValidationAttribute
            {
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {
                    if (value is DateTime timeValue)
                    {
                        DateTime now = DateTime.Now;
                        // Check if the date is today and time is not in the past
                        if (timeValue.Date == now.Date && timeValue.TimeOfDay >= now.TimeOfDay)
                        {
                            return ValidationResult.Success;
                        }
                        return new ValidationResult("The time must be a future time of today.");
                    }
                    return new ValidationResult("Invalid time.");
                }
            }
        }
    }
}