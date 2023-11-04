using AutoMapper;
using DTOExample.DTOS;
using DTOExample.EF;
using System.Collections.Generic;

namespace DTOExample.Mapper
{
    public class UMS_Mapper
    {

        public List<DepartmentDTO> DepartmentToDTO(List<Department> deparments)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentDTO>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<List<DepartmentDTO>>(deparments);
        }
        public Department DTOToDepartment(DepartmentDTO deparments)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentDTO, Department>();
            });
            var mapper = config.CreateMapper();
            return new Department()
            {
                name = deparments.name,
                headofDept = deparments.headofDept
            };
        }

        public List<DepartmentStudentDTO> DepartmentStudentDTO(List<Department> DeptsStuds)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<Department, DepartmentStudentDTO>();
            });

            var mapper = config.CreateMapper();

            return mapper.Map<List<DepartmentStudentDTO>>(DeptsStuds);
        }

        public Student DTOToStudent(StudentDTO students)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = config.CreateMapper();
            return new Student()
            {
                name = students.name,
                cgpa = students.cgpa,
                deptID = students.deptID
            };
        }
    }
}