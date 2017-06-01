using System.Linq;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.Faculty;

namespace SmartCardReader.ServiceLayer.Implementation
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _repository;

        public FacultyService(IFacultyRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<FacultyModel> GetFacultiesByUniversityId(int id)
        {
            return _repository.GetFacultiesByUniversityId(id);
        }
    }
}