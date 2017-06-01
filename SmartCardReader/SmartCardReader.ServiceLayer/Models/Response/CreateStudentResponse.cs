using System.Collections.Generic;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.ServiceLayer.Models.Response
{
    public class CreateStudentResponse
    {
        public List<UniversityModel> Universities { get; set; }
        public List<FacultyModel> Faculties { get; set; }
        public List<MajorBaseModel> Majors { get; set; }
    }
}