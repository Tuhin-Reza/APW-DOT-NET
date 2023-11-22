using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class DistributionCompleteDTO
    {
        public int id { get; set; }

        [Required]
        public string receiverType { get; set; }

        [Required]
        public Nullable<int> numberofReceiver { get; set; }
    }
}