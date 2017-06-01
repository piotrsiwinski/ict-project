using System.Linq;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.ServiceLayer.Base.MajorBase
{
    public interface IMajorBaseService
    {
        IQueryable<MajorBaseModel> GetMajorsByFacultyId(int id);
    }
}