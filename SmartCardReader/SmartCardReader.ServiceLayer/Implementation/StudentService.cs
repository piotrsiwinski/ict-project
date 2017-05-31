using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.Configuration;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService()
        {
            
        }

        public StudentService(IStudentRepository studentRepository) : this()
        {
            _studentRepository = studentRepository;
        }

        public ICollection<Student> GetAllStudents()
        {
            return _studentRepository.GetAll().ToList();
        }

        public ICollection<StudentResponse> GetAllStudentsResponse()
        {
            var students = _studentRepository.GetAll().ToList();
            var result = Mapper.Map<List<Student>, List<StudentResponse>>(students).ToList();
            return result;
        }
    }
}