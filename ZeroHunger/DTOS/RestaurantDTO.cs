using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class RestaurantDTO
    {
        public int id { get; set; }

        [Required]
        public string restaurantName { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public string contactPersonName { get; set; }

        [Required]
        public string contactPersonNumber { get; set; }

        [Required]
        public string contactPersonDesignation { get; set; }

        [Required]
        public string restaurantType { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public int userID { get; set; }
    }
}