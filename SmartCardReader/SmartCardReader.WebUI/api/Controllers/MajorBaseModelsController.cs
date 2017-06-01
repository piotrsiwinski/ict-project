using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.ServiceLayer.Base.Faculty;
using SmartCardReader.ServiceLayer.Base.MajorBase;
using SmartCardReader.ServiceLayer.DI;

namespace SmartCardReader.WebUI.api.Controllers
{
    public class MajorBaseModelsController : ApiController
    {
        private readonly IMajorBaseService _majorBaseService = AutofacResolver.Resolve<IMajorBaseService>();

        public MajorBaseModelsController()
        {
            
        }

        // GET: api/MajorBaseModels/5
        [ResponseType(typeof(MajorBaseModel))]
        public IHttpActionResult GetFacultyModel(int id)
        {
            var result = _majorBaseService.GetMajorsByFacultyId(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}