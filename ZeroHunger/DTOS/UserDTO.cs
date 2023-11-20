using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class UserDTO
    {
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
        public int roleID { get; set; }
    }
}