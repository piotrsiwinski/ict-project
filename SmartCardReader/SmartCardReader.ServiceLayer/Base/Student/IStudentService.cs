using System.Collections.Generic;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Base.Student
{
    public interface IStudentService
    {
        ICollection<DataAccessLayer.Models.Student> GetAllStudents();
        ICollection<StudentResponse> GetAllStudentsResponse();
    }
}