using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.DTOS
{
    public class assignAreaDTO
    {
        public int id { get; set; }

        [Required]
        public string area { get; set; }
    }
}