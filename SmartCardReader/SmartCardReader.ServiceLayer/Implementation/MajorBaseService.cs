using System.Linq;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.MajorBase;

namespace SmartCardReader.ServiceLayer.Implementation
{
    public class MajorBaseService : IMajorBaseService
    {
        private IMajorBaseRepository _majorBaseRepository;

        public MajorBaseService(IMajorBaseRepository majorBaseRepository)
        {
            _majorBaseRepository = majorBaseRepository;
        }

        public IQueryable<MajorBaseModel> GetMajorsByFacultyId(int id)
        {
            return _majorBaseRepository.GetMajorsIdAndNameByFacultyId(id);
        }
    }
}