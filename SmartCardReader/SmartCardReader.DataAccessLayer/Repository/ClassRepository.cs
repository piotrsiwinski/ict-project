using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;
using SmartCardReader.DataAccessLayer.Repository.Base;

namespace SmartCardReader.DataAccessLayer.Repository
{
    public class ClassRepository : AbstractRepository<Class>, IClassRepository
    {
        public ClassRepository(EfDbContext context) : base(context)
        {
        }
    }
}