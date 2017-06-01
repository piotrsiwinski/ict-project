using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.WebUI.Controllers
{
    public class AttendanceController : Controller
    {
        private EfDbContext db = new EfDbContext();

        // GET: Attendance
        public ActionResult Index(DateTime date)
        {
            var classesEntities = db.ClassesEntities.Include(s => s.Class).Include(s => s.Student);
            var result = classesEntities.Where(x=> x.Class.StartDateTime.Equals(date));
            return View(result.ToList());
        }

        // GET: Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassesEntity studentClassesEntity = db.ClassesEntities.Find(id);
            if (studentClassesEntity == null)
            {
                return HttpNotFound();
            }
            return View(studentClassesEntity);
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Id");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName");
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,ClassId")] StudentClassesEntity studentClassesEntity)
        {
            if (ModelState.IsValid)
            {
                db.ClassesEntities.Add(studentClassesEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Id", studentClassesEntity.ClassId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", studentClassesEntity.StudentId);
            return View(studentClassesEntity);
        }

        // GET: Attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassesEntity studentClassesEntity = db.ClassesEntities.Find(id);
            if (studentClassesEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Id", studentClassesEntity.ClassId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", studentClassesEntity.StudentId);
            return View(studentClassesEntity);
        }

        // POST: Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,ClassId")] StudentClassesEntity studentClassesEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentClassesEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Id", studentClassesEntity.ClassId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", studentClassesEntity.StudentId);
            return View(studentClassesEntity);
        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassesEntity studentClassesEntity = db.ClassesEntities.Find(id);
            if (studentClassesEntity == null)
            {
                return HttpNotFound();
            }
            return View(studentClassesEntity);
        }

        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentClassesEntity studentClassesEntity = db.ClassesEntities.Find(id);
            db.ClassesEntities.Remove(studentClassesEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
