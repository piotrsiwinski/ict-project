using Autofac;
using Autofac.Integration.Mvc;
using SmartCardReader.DataAccessLayer.Concrete;

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

        private static void RegisterTypes(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EfDbContext>().As<EfDbContext>();
        }
    }
}