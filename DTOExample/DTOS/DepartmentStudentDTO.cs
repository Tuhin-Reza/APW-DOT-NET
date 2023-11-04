using System.Collections.Generic;

namespace DTOExample.DTOS
{
    public class DepartmentStudentDTO : DepartmentDTO
    {
        public List<StudentDTO> Students { get; set; }

        public DepartmentStudentDTO()
        {
            Students = new List<StudentDTO>();
        }

    }
}