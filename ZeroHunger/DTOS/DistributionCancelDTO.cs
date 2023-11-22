using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class DistributionCancelDTO
    {
        public int id { get; set; }

        [Required]
        public string distributereason { get; set; }
    }
}