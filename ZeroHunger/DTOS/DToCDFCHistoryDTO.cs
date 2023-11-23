using System.Collections.Generic;

namespace ZeroHunger.DTOS
{
    public class DToCDFCHistoryDTO : DistributorDTO
    {
        public List<DistributorHistoryDTO> DistributorHistories { get; set; }
        public List<CollectorHistoryDTO> CollectorHistorys { get; set; }
        public List<FoodCollectRequestHistoryDTO> FoodCollectRequestHistorys { get; set; }

        public DToCDFCHistoryDTO()
        {
            DistributorHistories = new List<DistributorHistoryDTO>();
            CollectorHistorys = new List<CollectorHistoryDTO>();
            FoodCollectRequestHistorys = new List<FoodCollectRequestHistoryDTO>();
        }
    }
}