using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Common;
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
            List<Student> model = _databaseContext.Students.Include(x => x.Departman).Include(x => x.Teacher).Include(x => x.GuidanceCounselor).Include(x => x.Hobbies).Where(x => !x.IsDelete).ToList();

            //response<Roles> Response1 = new response<Roles>();
            //Response1.errorMessage.Add(new KeyValuePair<string, string>("hata 1", "hata"));
            return PartialView("_LoadStudentPartial", model);
        }


        public IActionResult DeleteStudent(DeleteModel model)
        {
            Student student = _databaseContext.Students.Find(model.Id);
            student.IsDelete = true;
            student.DeletionDescription = model.DeletionDescription;
            _databaseContext.SaveChanges();

            return RedirectToAction(nameof(LoadStudent));
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


        public IActionResult FilterStudent(PartialSearchModel model)
        {
            List<Student> allStudents = _databaseContext.Students
                            .Include(x => x.Departman)
                            .Include(x => x.Teacher)
                            .Include(x => x.GuidanceCounselor)
                            .Include(x => x.Hobbies)
                            .Where(x => !x.IsDelete).ToList();

            

            List<Student> filterStudents = allStudents;
            if (model.HobbyId != null)
            {
                filterStudents = allStudents.Where(x => x.Hobbies.All(h => h.Id == model.HobbyId)&&!x.IsDelete).ToList();
               
            }
            
            if (model.Fullname != null && model.TeacherId != null)
            {
                filterStudents = filterStudents.Where(x => x.Fullname==model.Fullname && x.TeacherId == model.TeacherId).ToList();
            }
            else if(model.Fullname != null && model.TeacherId == null)
            {
                filterStudents = filterStudents.Where(x => x.Fullname == model.Fullname).ToList();
            }
            else if(model.Fullname == null && model.TeacherId != null)
            {
                filterStudents = filterStudents.Where(x => x.TeacherId == model.TeacherId).ToList();
            }

            if(filterStudents.Count() == allStudents.Count()|| filterStudents.Count()==0)
            {
                Toastr Notification = new Toastr()
                {
                    ToastrType = "error",//success,info,warning,error
                    ToastrTitle = "Kayıt Bulunamadı",
                    ToastrMessage = "Aradığınız kriterlere uygun öğrenci bulunamadı. Tüm Kayıtları göstermek için arama kriterlerini temizleyin.",
                    ToastrButton = "yes",
                    Options = new ToastrOptions()
                    {
                        closeButton = false,
                        debug = false,
                        newestOnTop = false,
                        progressBar = false,
                        positionClass = ToastrPosition.top_right,
                        preventDuplicates=false,
                        
                        showDuration="300",
                        hideDuration="1000",
                        timeOut=0,
                        extendedTimeOut=0,
                        showEasing="swing",
                        hideEasing="linear",
                        showMethod="fadeIn",
                        hideMethod="faddeOut",
                        tapToDismiss=false
                    },
                    ShowToastr = true
                    
                };
                return PartialView("_toastrPartial", Notification);

            }

            return PartialView("_LoadStudentPartial", filterStudents);
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
                CloseModelPartial closeModel = new CloseModelPartial()
                {
                    ModalId = "modalform",
                    Notification = new Toastr()
                    {
                        ToastrType = "success",//success,info,warning,error
                        ToastrTitle = "Kayıt Başarılı",
                        ToastrMessage = "Öğrenci başarılı bir şekilde kayıt edildi.",
                        ShowToastr = true
                    }

                };
                
                return PartialView("_CloseModalPartial", closeModel);

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