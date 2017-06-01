namespace SmartCardReader.DataAccessLayer.Models
{
    public class StudentClassesEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}