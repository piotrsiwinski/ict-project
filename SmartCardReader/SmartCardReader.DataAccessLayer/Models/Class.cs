using System;
using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}