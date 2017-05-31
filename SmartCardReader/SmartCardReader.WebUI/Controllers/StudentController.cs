using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.DI;
using SmartCardReader.ServiceLayer.Implementation;
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
            var studentResponse = _studentService.GetAllStudentsResponse().FirstOrDefault();
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
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Id,Name,Surname,Transcript_number,Major,Email_address")] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
//             var Student
//             db.Students.Add(student);
//             db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentResponse = _studentService.GetAllStudentsResponse().FirstOrDefault();
            StudentViewModel student = Mapper.Map<StudentResponse, StudentViewModel>(studentResponse);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Surname,Transcript_number,Major,Email_address")] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
//             db.Entry(student).State = EntityState.Modified;
//             db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentResponse = _studentService.GetAllStudentsResponse().FirstOrDefault();
            StudentViewModel student = Mapper.Map<StudentResponse, StudentViewModel>(studentResponse);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var studentResponse = _studentService.GetAllStudentsResponse().FirstOrDefault();
            StudentViewModel student = Mapper.Map<StudentResponse, StudentViewModel>(studentResponse);
//         db.Students.Remove(student);
//         db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}