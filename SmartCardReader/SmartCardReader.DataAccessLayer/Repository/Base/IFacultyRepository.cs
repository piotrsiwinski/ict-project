using System.Linq;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;

namespace SmartCardReader.DataAccessLayer.Repository.Base
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        IQueryable<FacultyModel> GetUniversitiesIdAndName();
        IQueryable<FacultyModel> GetFacultiesByUniversityId(int id);

    }
}