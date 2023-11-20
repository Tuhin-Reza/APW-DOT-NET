using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class CollectorDTO
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string contactNumber { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string vehicleType { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public int userID { get; set; }
    }
}