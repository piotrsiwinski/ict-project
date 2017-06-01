using System.Linq;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;
using SmartCardReader.DataAccessLayer.Repository.Base;

namespace SmartCardReader.DataAccessLayer.Repository
{
    public class FacultyRepository : AbstractRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(EfDbContext context) : base(context)
        {
        }

        public IQueryable<FacultyModel> GetUniversitiesIdAndName()
        {
            return Context.Faculties.Select(faculty => new FacultyModel {Id = faculty.Id, Name = faculty.Name});
        }

        public IQueryable<FacultyModel> GetFacultiesByUniversityId(int id)
        {
            return Context.Faculties.Where(x => x.University.Id== id).Select(faculty => new FacultyModel {Id = faculty.Id, Name = faculty.Name});
        }
    }
}