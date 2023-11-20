//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodCollectRequestHistory
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
    
        public virtual Collector Collector { get; set; }
        public virtual Distributor Distributor { get; set; }
        public virtual FoodCollectRequest FoodCollectRequest { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
