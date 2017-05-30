using System.Data.Entity;
using SmartCardReader.DataAccessLayer.Concrete;

namespace SmartCardReader.DataAccessLayer.Initializers
{
    public class CustomDbInitializer : DropCreateDatabaseAlways<EfDbContext>
    {
        public CustomDbInitializer()
        {
        }

        protected override void Seed(EfDbContext context)
        {
            context.SaveChanges();
            base.Seed(context);
        }
    }
}