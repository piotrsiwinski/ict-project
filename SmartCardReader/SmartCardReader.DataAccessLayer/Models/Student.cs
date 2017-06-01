using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Student
    {
        public Student()
        {
            Majors = new HashSet<Major>();
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IndexNumber { get; set; }
        public virtual ICollection<Major> Majors { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}