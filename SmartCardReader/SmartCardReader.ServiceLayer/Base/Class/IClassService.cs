using System.Collections.Generic;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Base.Class
{
    public interface IClassService
    {
        ICollection<DataAccessLayer.Models.Class> GetClasses();
        ICollection<ClassResponse> GetClassesResponse();
    }
}