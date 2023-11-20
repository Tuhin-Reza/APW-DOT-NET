using System.Collections.Generic;

namespace ZeroHunger.DTOS
{
    public class RestaurantFoodCollectRequestDTO : RestaurantDTO
    {
        public List<FoodCollectRequestDTO> FoodCollectRequests { get; set; }
        public RestaurantFoodCollectRequestDTO()
        {
            FoodCollectRequests = new List<FoodCollectRequestDTO>();
        }
    }
}