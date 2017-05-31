using Autofac;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Repository;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.Class;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.Implementation;

namespace SmartCardReader.ServiceLayer.DI
{
    public class AutofacResolver
    {
        private static IContainer _container;

        static AutofacResolver()
        {
            Build();
        }

        public static IContainer GetContainer()
        {
            return _container;
        }

        private static void Build()
        {
            var containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            RegisterTypes(containerBuilder);
            _container = containerBuilder.Build();
        }

        public static T Resolve<T>()
        {
            var scope = _container.BeginLifetimeScope();
            return scope.Resolve<T>();
        }

        private static void RegisterTypes(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EfDbContext>().As<EfDbContext>();
            containerBuilder.RegisterType<ClassRepository>().As<IClassRepository>();
            containerBuilder.RegisterType<ClassService>().As<IClassService>();
            containerBuilder.RegisterType<StudentRepository>().As<IStudentRepository>();
            containerBuilder.RegisterType<StudentService>().As<IStudentService>();
        }
    }
}