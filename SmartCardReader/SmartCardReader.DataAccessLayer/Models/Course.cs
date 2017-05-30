using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Course
    {
        public Course()
        {
            Majors = new HashSet<Major>();
            Classes = new HashSet<Class>();
            Lecturers = new HashSet<Lecturer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Major> Majors { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}