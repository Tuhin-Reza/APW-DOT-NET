using DTOExample.DTOS;
using DTOExample.EF;
using DTOExample.Mapper;
using System.Linq;
using System.Web.Mvc;

namespace DTOExample.Controllers
{
    public class DepartmentController : Controller
    {
        private UMSDBEntities db;
        private UMS_Mapper dtoConverter;
        public DepartmentController()
        {
            db = new UMSDBEntities();
            dtoConverter = new UMS_Mapper();
        }


        public ActionResult DepartmentView()
        {
            var data = db.Departments.ToList();
            var departData = dtoConverter.DepartmentToDTO(data);
            return View(departData);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(DepartmentDTO info)
        {
            if (ModelState.IsValid)
            {
                var departData = dtoConverter.DTOToDepartment(info);
                db.Departments.Add(departData);
                db.SaveChanges();
                return RedirectToAction("DepartmentView");
            }
            return View(info);
        }

        public ActionResult StudentView()
        {
            var data = db.Departments.ToList();
            var studData = dtoConverter.DepartmentStudentDTO(data);
            return View(studData);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            var data = db.Departments.ToList();
            var departData = dtoConverter.DepartmentToDTO(data);
            ViewBag.DeptData = departData;
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDTO info)
        {
            var data = db.Departments.ToList();
            var departData = dtoConverter.DepartmentToDTO(data);
            ViewBag.DeptData = departData;

            if (ModelState.IsValid)
            {
                var studData = dtoConverter.DTOToStudent(info);
                db.Students.Add(studData);
                db.SaveChanges();
                return RedirectToAction("StudentView");
            }
            return View(info);
        }

    }
}