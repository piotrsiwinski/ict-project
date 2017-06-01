using System;
using System.Collections.Generic;

namespace SmartCardReader.ServiceLayer.Models.Response
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public List<string> Majors { get; set; }
        public List<string> Classes { get; set; }
    }
}