using System;

namespace ZeroHunger.DTOS
{
    public class FoodCollectRequestHistoryDTO
    {
        public int id { get; set; }
        public string requestStatus { get; set; }
        public string collectReason { get; set; }
        public Nullable<System.DateTime> collectDate { get; set; }
        public Nullable<System.DateTime> collectTime { get; set; }
        public Nullable<int> requestID { get; set; }
        public Nullable<int> restaurantID { get; set; }
        public Nullable<int> collectorID { get; set; }
        public Nullable<int> distributorID { get; set; }
    }
}