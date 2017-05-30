using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class University
    {
        public University()
        {
            Faculties = new HashSet<Faculty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Faculty> Faculties { get; set; }
    }
}