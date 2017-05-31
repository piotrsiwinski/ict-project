using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;
using SmartCardReader.DataAccessLayer.Repository.Base;

namespace SmartCardReader.DataAccessLayer.Repository
{
    public class StudentRepository : AbstractRepository<Student>, IStudentRepository
    {
        public StudentRepository(EfDbContext context) : base(context)
        {
        }
    }
}