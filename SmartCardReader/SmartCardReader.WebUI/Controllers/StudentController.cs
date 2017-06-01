using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.DI;
using SmartCardReader.ServiceLayer.Implementation;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;
using SmartCardReader.WebUI.Configuration;
using SmartCardReader.WebUI.Models;
using SmartCardReader.WebUI.ViewModels;

namespace SmartCardReader.WebUI.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService = AutofacResolver.Resolve<IStudentService>();

        // GET: Students
        public ActionResult Index()
        {
            var studentResponse = _studentService.GetAllStudentsResponse().ToList();
            return View(Mapper.Map<List<StudentResponse>, List<StudentViewModel>>(studentResponse));
        }

        // GET: Students/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TODO : ADD Get Student by ID
            var studentResponse = _studentService.GetStudent(id.Value);
            StudentViewModel student = Mapper.Map<StudentResponse, StudentViewModel>(studentResponse);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create

        public ActionResult Create()
        {
            var result = _studentService.GetDataToCreateStudent();
            var test = Mapper.Map<CreateStudentResponse, StudentViewModel>(result);
            return View(test);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _studentService.AddStudent(Mapper.Map<StudentViewModel, StudentRequest>(student));

            return RedirectToAction("Index");
        }

        // GET: Students/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentResponse = _studentService.GetStudent(id.Value);
            StudentViewModel student = Mapper.Map<StudentResponse, StudentViewModel>(studentResponse);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _studentService.UpdateStudent(Mapper.Map<StudentViewModel, StudentRequest>(student));
            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentResponse = _studentService.GetStudent(id.Value);
            if (studentResponse == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<StudentResponse, StudentViewModel>(studentResponse));
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var studentResponse = _studentService.GetStudent(id);
            _studentService.DeleteStudent(Mapper.Map<StudentResponse, StudentRequest>(studentResponse));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}