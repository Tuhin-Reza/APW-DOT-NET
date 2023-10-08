using System;
using System.ComponentModel.DataAnnotations;

namespace lab4.Models
{
    public class SignUp
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "*between 4 to 50 characters.")]
        [RegularExpression(@"^[a-zA-Z.\-\s!@#$%^&*()_+=,<>?\w\s]*$", ErrorMessage = "*contain letters,spaces,dots,dashes & special characters")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z_-]{4,12}$", ErrorMessage = "*between 4 to 12 characters & contain numbers, dashes, and underscores")]
        public string user_id { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z].*[a-z])(?=.*[0-9\W]).{8,}$", ErrorMessage = "8(4(1CL+2L+)+4(1SC+1N))")]
        public string password { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "id must be exactly 8 characters long.")]
        [RegularExpression(@"^\d{2}-\d{5}-\d$", ErrorMessage = "*format xx-xxxxx-x with only numbers and dashes")]
        public string id { get; set; }


        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d@student.aiub.edu$", ErrorMessage = "*format xx-xxxxx-x@student.aiub.edu")]
        [id_email_Match]
        public string email { get; set; }


        [DataType(DataType.Date)]
        [ageCalculate(ErrorMessage = "*age must be greater than 18")]
        public DateTime dob { get; set; }
    }
}