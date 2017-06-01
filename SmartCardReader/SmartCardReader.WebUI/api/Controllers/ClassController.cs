using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Converters;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.ServiceLayer.Base.Class;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.DI;
using SmartCardReader.ServiceLayer.Implementation;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.WebUI.api.Controllers
{
    public class ClassController : ApiController
    {
        private readonly IClassService _classService = AutofacResolver.Resolve<IClassService>();
        private readonly IStudentService _studentService = AutofacResolver.Resolve<IStudentService>();
        private EfDbContext db = new EfDbContext();

        public ClassController()
        {
        }

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Class
        public List<ClassResponse> GetClasses()
        {
            var result = _classService.GetClassesResponse().ToList();
            return result;
        }


        // POST: api/Class
        [ResponseType(typeof(Class))]
        public IHttpActionResult PostClass([FromBody] ClassRequest classRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentClass = new StudentClassesEntity
            {
                ClassId = classRequest.ClassId,
                StudentId = classRequest.StudentId
            };

            var ctx = new EfDbContext();
            try
            {
                ctx.ClassesEntities.Add(studentClass);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            finally
            {
                ctx.Dispose();
            }
            return CreatedAtRoute("DefaultApi", new {id = classRequest.StudentId}, classRequest);
        }

        private bool ClassExists(int id)
        {
            return db.Classes.Count(e => e.Id == id) > 0;
        }
    }
}