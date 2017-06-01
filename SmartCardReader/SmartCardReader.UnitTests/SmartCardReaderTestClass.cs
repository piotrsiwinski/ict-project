using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCardReader.DataAccessLayer.Concrete;
using Autofac;
using SmartCardReader.ServiceLayer.Base.Class;
using SmartCardReader.ServiceLayer.Base.Student;
using SmartCardReader.ServiceLayer.Configuration;
using SmartCardReader.ServiceLayer.DI;

namespace SmartCardReader.UnitTests
{
    [TestClass]
    public class SmartCardReaderTestClass
    {
        public SmartCardReaderTestClass()
        {
            //AutoMapperServiceConfiguration.Configure();
        }
        private static IContainer Container { get; set; }
        [TestMethod]
        public void EfDbContextTest()
        {
            var _ctx = new EfDbContext();
            var result = _ctx.Courses.ToList();
        }

        [TestMethod]
        public void TestClassService()
        {
            var classService = AutofacResolver.Resolve<IClassService>();
            var result = classService.GetClassesResponse().ToList();
        }

        [TestMethod]
        public void TestStudentService()
        {
            var studentService = AutofacResolver.Resolve<IStudentService>();
            var result = studentService.GetAllStudentsResponse().ToList();
        }
    }
}