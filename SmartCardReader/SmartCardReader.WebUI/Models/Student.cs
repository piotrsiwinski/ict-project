using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCardReader.WebUI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Transcript_number { get; set; }
        public string Major { get; set; }
        public string Email_address { get; set; }



    }
}