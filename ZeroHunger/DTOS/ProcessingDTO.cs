using System;

namespace ZeroHunger.DTOS
{
    public class ProcessingDTO
    {
        public int id { get; set; }
        public Nullable<int> requestID { get; set; }
        public Nullable<int> collectorID { get; set; }
        public Nullable<int> distributorID { get; set; }
        public string area { get; set; }
    }
}