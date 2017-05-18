using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartCardReader.WebUI.Models;

namespace SmartCardReader.WebUI.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}