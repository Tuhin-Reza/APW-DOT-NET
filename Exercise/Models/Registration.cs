using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(8, ErrorMessage = "Name cannot exceed 8 characters.")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "capital letter+not numeric+cannot contain special characters.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string country { get; set; }

        [Required(ErrorMessage = "Hobbies is required.")]
        public string[] hobbies { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\d{5}-\d{6}$", ErrorMessage = "Format 01725-653462.")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z]\d[\W_]{1,6}$", ErrorMessage = "alphabet+numbers+special character.")]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 8 characters.")]
        public string username { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9]*@gmail\.com$", ErrorMessage = "Only Gmail addresses are allowed.")]

        public string email { get; set;  }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*\d)(?=.*\W).{3,8}$", ErrorMessage = "min-length 3+numeric+special character.")]
        public string password { get; set; }
    }
}