using SmartCardReader.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCardReader.WebUI.Controllers
{

    public class SubjectsController : Controller
    {
        private ApplicationDbContext baza = new ApplicationDbContext();
        // GET: Subjects
        public ActionResult Index()
        {


            return View(baza.Subjects.ToList());
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,TeaTeacher_ID,Teacher_Name,Teacher_Surname,Subject_Name")] Subject subject)
        {

            if (ModelState.IsValid)
            {

                baza.Subjects.Add(subject);

                baza.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(subject);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Subject subject = baza.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Subject subject = baza.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeaTeacher_ID,Teacher_Name,Teacher_Surname,Subject_Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                baza.Entry(subject).State = EntityState.Modified;
                baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public ActionResult Remove(int id)
        {
            var temp = baza.Subjects.Find(id);
            baza.Subjects.Remove(temp);
            baza.SaveChanges();
            return RedirectToAction("Index");
        }


   
    }
}