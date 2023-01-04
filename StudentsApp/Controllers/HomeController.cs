using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Entities;
using StudentsApp.Models;
using System.Diagnostics;

namespace StudentsApp.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext _databaseContext;

        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadStudent()
        {
            List<Student> model = _databaseContext.Students.Include(x => x.Departman).Include(x => x.Teacher).Include(x => x.GuidanceCounselor).Include(x => x.Hobbies).ToList();
            return PartialView("_LoadStudentPartial", model);
        }
        public IActionResult GetSeacrhPagePartial()
        {
            PartialSearchModel model = new PartialSearchModel()
            {
                Hobbies = new SelectList(_databaseContext.Hobbies.ToList(), nameof(Hobby.Id), nameof(Hobby.Name)),
                Teachers = new SelectList(_databaseContext.Teachers.ToList(), nameof(Teacher.Id), nameof(Teacher.Name)),

            };
            return PartialView("_SearchPartial", model);
        }

        //Get: /Home/GetCreatePagePartial
        public IActionResult GetCreatePagePartial()
        {
            PartialCreateModel model = new PartialCreateModel()
            {
                Departmans = new SelectList(_databaseContext.Departmans.ToList(), nameof(Departman.Id), nameof(Departman.Name)),
                Hobbies = new SelectList(_databaseContext.Hobbies.ToList(), nameof(Hobby.Id), nameof(Hobby.Name)),
                Teachers = new SelectList(_databaseContext.Teachers.ToList(), nameof(Teacher.Id), nameof(Teacher.Name)),
                GuidanceCouncelors = new SelectList(_databaseContext.GuidanceCounselors.ToList(), nameof(GuidanceCounselor.Id), nameof(GuidanceCounselor.Name)),
                FormType = (byte)WhichForm.pageForm
            };
            return PartialView("_CreateStudentPartial", model);
        }

        [HttpPost]
        public IActionResult PostCreatePartial(PartialCreateModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student()
                {
                    Fullname = model.Fullname,
                    DepartmanId = model.DepartmanId,
                    TeacherId = model.TeacherId,
                    GuidanceCounselorId = model.GuidanceCounselorId,
                    Hobbies = new List<Hobby>()
                    {
                        _databaseContext.Hobbies.Find(model.HobbyId)
                    }
                };
                _databaseContext.Students.Add(student);
                _databaseContext.SaveChanges();

            }
            model.Departmans = new SelectList(_databaseContext.Departmans.ToList(), nameof(Departman.Id), nameof(Departman.Name));
            model.Hobbies = new SelectList(_databaseContext.Hobbies.ToList(), nameof(Hobby.Id), nameof(Hobby.Name));
            model.Teachers = new SelectList(_databaseContext.Teachers.ToList(), nameof(Teacher.Id), nameof(Teacher.Name));
            model.GuidanceCouncelors = new SelectList(_databaseContext.GuidanceCounselors.ToList(), nameof(GuidanceCounselor.Id), nameof(GuidanceCounselor.Name));
            

            return PartialView("_CreateStudentPartial", model);
        }









        //Get: /Home/GetCreatModalPartial
        public IActionResult GetCreatModalPartial()
        {
            PartialCreateModel model = new PartialCreateModel()
            {
                Departmans = new SelectList(_databaseContext.Departmans.ToList(), nameof(Departman.Id), nameof(Departman.Name)),
                Hobbies = new SelectList(_databaseContext.Hobbies.ToList(), nameof(Hobby.Id), nameof(Hobby.Name)),
                Teachers = new SelectList(_databaseContext.Teachers.ToList(), nameof(Teacher.Id), nameof(Teacher.Name)),
                GuidanceCouncelors = new SelectList(_databaseContext.GuidanceCounselors.ToList(), nameof(GuidanceCounselor.Id), nameof(GuidanceCounselor.Name)),
                FormType = (byte)WhichForm.modalForm
            };
            return PartialView("_CreateStudentPartial", model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}