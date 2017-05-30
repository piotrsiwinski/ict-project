using System;
using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Major
    {
        public Major()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public DateTime StartYear { get; set; }
        public virtual MajorBase MajorBase { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}