using System.ComponentModel.DataAnnotations;
using static ZeroHunger.CustomValidation.CollectRequestValidation;

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
        [Range(10, int.MaxValue, ErrorMessage = "The number of packages must be at least 10.")]
        public int numberofPackages { get; set; }

        [Required]
        public string foodDescription { get; set; }


        [Required]

        public System.DateTime availableDate { get; set; }

        [Required]
        public System.DateTime preferredCollectTime { get; set; }


        [DateTimeValoidation]
        public System.DateTime expiryDate { get; set; }

        [Required]
        public string pickUpLocation { get; set; }

        public string statusType { get; set; }
        public int retaurantID { get; set; }
    }
}