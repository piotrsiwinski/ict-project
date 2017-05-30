using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Lecturer
    {
        public Lecturer()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}