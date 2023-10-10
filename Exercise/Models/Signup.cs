using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class Signup
    {
        [Required]
        [SignupFnameValidation]
        public string fname { get; set; }

        [Required]
        [SignuplnameValidation]
        public string lname { get; set; }
    }
}