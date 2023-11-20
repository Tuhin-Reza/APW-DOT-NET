using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class FoodCollectRequestDTO
    {
        public int id { get; set; }

        [Required]
        public string foodType { get; set; }

        [Required]
        public string packagingType { get; set; }

        [Required]
        public int numberofPackages { get; set; }

        [Required]
        public string foodDescription { get; set; }

        [Required]
        public System.DateTime availableDate { get; set; }

        [Required]
        public System.DateTime preferredCollectTime { get; set; }

        [Required]
        public System.DateTime expiryDate { get; set; }

        [Required]
        public string pickUpLocation { get; set; }

        public string statusType { get; set; }
        public int retaurantID { get; set; }
    }
}