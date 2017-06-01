using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartCardReader.DataAccessLayer.Initializers;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.DataAccessLayer.Concrete
{
    public class EfDbContext : IdentityDbContext<Account>
    {
        private static string connectionString= $"data source=(localdb)\\MSSQLLocalDB;initial catalog=ictDb_dev;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public EfDbContext() : base(connectionString)
        {
            Database.SetInitializer(new CustomDbInitializer());
        }

        public static EfDbContext Create()
        {
            return new EfDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOptional(d => d.Lecturer).WithRequired(p => p.Account);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<MajorBase> MajorBase { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<StudentClassesEntity> ClassesEntities { get; set; }
    }
}