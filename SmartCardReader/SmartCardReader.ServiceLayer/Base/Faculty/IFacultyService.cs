using System.Linq;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.ServiceLayer.Base.Faculty
{
    public interface IFacultyService
    {
        IQueryable<FacultyModel> GetFacultiesByUniversityId(int id);
    }
}