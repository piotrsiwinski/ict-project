using System.Linq;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;

namespace SmartCardReader.DataAccessLayer.Repository.Base
{
    public interface IMajorBaseRepository : IRepository<MajorBase>
    {
        IQueryable<MajorBaseModel> GetMajorsIdAndName();
        IQueryable<MajorBaseModel> GetMajorsIdAndNameByFacultyId(int id);
    }
}