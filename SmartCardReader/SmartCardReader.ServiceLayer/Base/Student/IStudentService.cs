using System.Collections.Generic;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Base.Student
{
    public interface IStudentService
    {
        CreateStudentResponse GetDataToCreateStudent();
        ICollection<DataAccessLayer.Models.Student> GetAllStudents();
        ICollection<StudentResponse> GetAllStudentsResponse();

        StudentResponse GetStudent(int id);

        void AddStudent(StudentRequest studentRequest);

        void DeleteStudent(StudentRequest studentRequest);

        void UpdateStudent(StudentRequest studentRequest);
    }
}