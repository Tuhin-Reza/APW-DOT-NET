using System.Collections.Generic;

namespace DTOExample.DTOS
{
    public class DepartmentCourseDTO : DepartmentDTO
    {
        public List<CourseDTO> Courses { get; set; }
        public DepartmentCourseDTO()
        {
            Courses = new List<CourseDTO>();
        }
    }
}