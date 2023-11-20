using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class ReasonDTO
    {

        public int id { get; set; }

        [Required]
        public string reason { get; set; }
    }
}