using System;
using System.Collections.Generic;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.ServiceLayer.Models.Response
{
    public class ClassResponse
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string CourseName { get; set; }
        public List<string> Lecturers { get; set; }
        
    }
}