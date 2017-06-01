using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.Configuration;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IMajorBaseRepository _majorBaseRepository;

        public StudentService(IFacultyRepository facultyRepository, IUniversityRepository universityRepository, IMajorBaseRepository majorBaseRepository)
        {
            _facultyRepository = facultyRepository;
            _universityRepository = universityRepository;
            _majorBaseRepository = majorBaseRepository;
        }

        public StudentService(IStudentRepository studentRepository, IFacultyRepository facultyRepository, IUniversityRepository universityRepository, IMajorBaseRepository majorBaseRepository) : this(facultyRepository, universityRepository, majorBaseRepository)
        {
            _studentRepository = studentRepository;
        }

        public CreateStudentResponse GetDataToCreateStudent()
        {
            var student = new CreateStudentResponse
            {
                //Faculties = _facultyRepository.GetAll().Select(x => x.Name).ToList(),
                //Majors = _majorBaseRepository.GetAll().Select(x => x.Name).ToList(),
                Universities = _universityRepository.GetUniversitiesIdAndName().ToList()
            };
            return student;
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

        public StudentResponse GetStudent(int id)
        {
            var student = _studentRepository.Get(id);
            return Mapper.Map<Student, StudentResponse>(student);
        }

        public void AddStudent(StudentRequest studentRequest)
        {
            
            var student = Mapper.Map<StudentRequest, Student>(studentRequest);
            student.Id = 0;
            _studentRepository.Add(student);
        }

        public void DeleteStudent(StudentRequest studentRequest)
        {
            _studentRepository.Remove(Mapper.Map<StudentRequest, Student>(studentRequest));
        }

        public void UpdateStudent(StudentRequest studentRequest)
        {
            _studentRepository.Edit(Mapper.Map<StudentRequest, Student>(studentRequest));
        }
        
    }
}