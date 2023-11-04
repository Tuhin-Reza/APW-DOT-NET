using DTOExample.CustomValidation;
namespace DTOExample.DTOS
{
    public class StudentDTO
    {
        public int id { get; set; }

        [NameAttribute(ErrorMessage = "Name is required")]
        public string name { get; set; }


        [CGPAAttribute(ErrorMessage = "CGPA must be a numeric value")]
        public string cgpa { get; set; }


        [DeptIDAttribute(ErrorMessage = "Please select a valid department")]
        public int deptID { get; set; }
    }
}