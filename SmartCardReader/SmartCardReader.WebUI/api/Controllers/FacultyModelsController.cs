using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.ServiceLayer.Base.Faculty;
using SmartCardReader.ServiceLayer.DI;
using SmartCardReader.ServiceLayer.Implementation;

namespace SmartCardReader.WebUI.api.Controllers
{
    public class FacultyModelsController : ApiController
    {

        private readonly IFacultyService _facultyService = AutofacResolver.Resolve<IFacultyService>();
      

        // GET: api/FacultyModels/5
        [ResponseType(typeof(FacultyModel))]
        public IHttpActionResult GetFacultyModel(int id)
        {
            var result = _facultyService.GetFacultiesByUniversityId(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
       
    }
}