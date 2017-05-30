using System.Collections.Generic;

namespace SmartCardReader.DataAccessLayer.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public University University { get; set; }
        public ICollection<MajorBase> MajorBases { get; set; }
    }
}