using System.Collections.Generic;

namespace ZeroHunger.DTOS
{
    public class FoodCollectRequestFCRHistoryDTO : FoodCollectRequestDTO
    {
        public List<FCRHistoryDTO> FoodCollectRequestHistorys { get; set; }
        public FoodCollectRequestFCRHistoryDTO()
        {
            FoodCollectRequestHistorys = new List<FCRHistoryDTO>();
        }
    }
}

