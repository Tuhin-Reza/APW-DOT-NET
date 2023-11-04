using System.ComponentModel.DataAnnotations;

namespace DTOExample.DTOS
{
    public class DepartmentDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "HeadofDept is required.")]
        public string headofDept { get; set; }
    }
}