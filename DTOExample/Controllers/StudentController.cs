using DTOExample.EF;
using System.Web.Mvc;


namespace DTOExample.Controllers
{
    public class StudentController : Controller
    {

        private UMSDBEntities db;
        public StudentController()
        {
            db = new UMSDBEntities();
        }

        //[Logged]
        ////public ActionResult DepartmentView()
        ////{
        ////    //var data = db.Departments.ToList();

        ////    //var cofig = new MapperConfiguration(cfg =>
        ////    //{
        ////    //    cfg.CreateMap<Department, DepartmentDTO>();
        ////    //});
        ////    //var mapper = new Mapper(cofig);
        ////    //var data2 = mapper.Map<List<DepartmentDTO>>(data);
        ////    //return View(data2);
        ////}

        //[Logged]
        //[HttpGet]
        //public ActionResult AddDepartment()
        //{
        //    return View();
        //}

        //public ActionResult Test()
        //{
        //    var students = db.Students.ToList();
        //    var departments = db.Departments.ToList();
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Department, DepartmentStudentDTO>();
        //        cfg.CreateMap<Student, StudentDTO>();
        //    });
        //    var mapper = new Mapper(config);

        //    // Map the list of departments to a list of DepartmentStudentDTO objects
        //    var data = mapper.Map<List<DepartmentStudentDTO>>(departments);

        //    return View(data);
        //}


        //[Logged]
        //[HttpPost]
        //public ActionResult AddDepartment(DepartmentDTO info)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cofig = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<DepartmentDTO, Department>();

        //        });
        //        var mapper = new Mapper(cofig);
        //        var data2 = mapper.Map<Department>(info);
        //        db.Departments.Add(data2);
        //        db.SaveChanges();
        //        return RedirectToAction("DepartmentView");
        //    }
        //    return View(info);
        //}


        //public ActionResult RemoveDepartment()
        //{

        //    return View();
        //}
        //public ActionResult EditDepartment()
        //{
        //    return View();
        //}


        //[Logged]
        //public ActionResult StudentView()
        //{
        //    var students = db.Students.ToList();
        //    var departments = db.Departments.ToList();
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Department, DepartmentStudentDTO>();
        //        cfg.CreateMap<Student, StudentDTO>();
        //    });
        //    var mapper = new Mapper(config);
        //    var data = mapper.Map<List<DepartmentStudentDTO>>(departments);

        //    return View(data);
        //}


        //[Logged]
        //[HttpGet]
        //public ActionResult AddStudent()
        //{
        //    var data = db.Departments.ToList();
        //    var cofig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Department, DepartmentDTO>();
        //    });
        //    var mapper = new Mapper(cofig);
        //    var data2 = mapper.Map<List<DepartmentDTO>>(data);
        //    ViewBag.deptName = data2;
        //    return View();
        //}

        //[Logged]
        //[HttpPost]
        //public ActionResult AddStudent(StudentDTO info)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cofig = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<StudentDTO, Student>();
        //        });
        //        var mapper = new Mapper(cofig);
        //        var data2 = mapper.Map<Student>(info);
        //        db.Students.Add(data2);
        //        db.SaveChanges();
        //        return RedirectToAction("StudentView");
        //    }

        //    var deptData = db.Departments.ToList();
        //    var deptcofig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Department, DepartmentDTO>();
        //    });
        //    var deptmapper = new Mapper(deptcofig);
        //    var deptData2 = deptmapper.Map<List<DepartmentDTO>>(deptData);
        //    ViewBag.deptName = deptData2;

        //    return View(info);
        //}


        //public ActionResult EditStudent()
        //{
        //    return View();
        //}

        //public ActionResult RemoveStudent()
        //{
        //    return View();
        //}

        //public ActionResult Index()
        //{
        //    Session["user"] = "Tuhin";
        //    return View();
        //}
    }
}