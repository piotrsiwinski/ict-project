using System.Collections.Generic;
using System.Linq;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;

namespace SmartCardReader.DataAccessLayer.Repository.Base
{
    public interface IUniversityRepository : IRepository<University>
    {
        IQueryable<UniversityModel> GetUniversitiesIdAndName();
        IQueryable<FacultyModel> GetFacultiesByUniversityId(int id);
    }
}