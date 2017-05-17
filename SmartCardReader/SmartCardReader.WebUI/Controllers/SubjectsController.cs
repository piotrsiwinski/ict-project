using SmartCardReader.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SmartCardReader.WebUI.Controllers
{

    public class SubjectsController : Controller
    {
        private ApplicationDbContext baza = new ApplicationDbContext();
      
        // GET: Subjects
       
        public ActionResult Index()
        {
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string strCurrentUserId = User.Identity.GetUserId();
                var subjects = baza.Subjects.Where(s => s.Teacher_ID == strCurrentUserId).ToList();


                return View(subjects);
            }

            return RedirectToAction("Login", "Account");

            
        }

      
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Create([Bind(Include = "Id,Teacher_Name,Teacher_Surname,Subject_Name")] Subject subject)
        {

            if (ModelState.IsValid)
            {
                
                string strCurrentUserId = User.Identity.GetUserId();
                subject.Teacher_ID =strCurrentUserId;

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