using System.Linq;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;
using SmartCardReader.DataAccessLayer.Repository.Base;

namespace SmartCardReader.DataAccessLayer.Repository
{
    public class MajorBaseRepository : AbstractRepository<MajorBase>, IMajorBaseRepository
    {
        public MajorBaseRepository(EfDbContext context) : base(context)
        {
        }

        public IQueryable<MajorBaseModel> GetMajorsIdAndName()
        {
            return Context.MajorBase.Select(mb => new MajorBaseModel {Id = mb.Id, Name = mb.Name});
        }

        public IQueryable<MajorBaseModel> GetMajorsIdAndNameByFacultyId(int id)
        {
            return Context.MajorBase.Where(mb => mb.Faculty.Id == id)
                .Select(mb => new MajorBaseModel {Id = mb.Id, Name = mb.Name});
        }
    }
}