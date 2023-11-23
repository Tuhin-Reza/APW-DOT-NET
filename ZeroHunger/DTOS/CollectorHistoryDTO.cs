using System;

namespace ZeroHunger.DTOS
{
    public class CollectorHistoryDTO
    {
        public int id { get; set; }
        public Nullable<System.DateTime> collectDate { get; set; }
        public Nullable<System.DateTime> collectTime { get; set; }
        public string pickUpLocation { get; set; }
        public string TransportationMethod { get; set; }
        public string deliveryLocation { get; set; }
        public Nullable<System.DateTime> handoverDate { get; set; }
        public Nullable<System.DateTime> handoverTime { get; set; }
        public Nullable<int> requestID { get; set; }
        public Nullable<int> distributorID { get; set; }
        public Nullable<int> collectorID { get; set; }
    }
}