using System;

namespace ZeroHunger.DTOS
{
    public class DistributorHistoryDTO
    {
        public int id { get; set; }
        public Nullable<System.DateTime> collectDate { get; set; }
        public Nullable<System.DateTime> collectTime { get; set; }
        public string distributeStatus { get; set; }
        public string distributereason { get; set; }
        public Nullable<System.DateTime> distributeDate { get; set; }
        public Nullable<System.DateTime> distributTime { get; set; }
        public string distributeLocation { get; set; }
        public string receiverType { get; set; }
        public Nullable<int> numberofReceiver { get; set; }
        public Nullable<int> requestID { get; set; }
        public Nullable<int> collectorID { get; set; }
        public Nullable<int> distributorID { get; set; }

    }
}