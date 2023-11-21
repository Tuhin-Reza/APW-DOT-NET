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
    
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.FoodCollectRequestHistorys = new HashSet<FoodCollectRequestHistory>();
            this.FoodCollectRequests = new HashSet<FoodCollectRequest>();
        }
    
        public int id { get; set; }
        public string restaurantName { get; set; }
        public string location { get; set; }
        public string contactPersonName { get; set; }
        public string contactPersonNumber { get; set; }
        public string contactPersonDesignation { get; set; }
        public string restaurantType { get; set; }
        public string email { get; set; }
        public int userID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodCollectRequestHistory> FoodCollectRequestHistorys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodCollectRequest> FoodCollectRequests { get; set; }
        public virtual User User { get; set; }
    }
}
