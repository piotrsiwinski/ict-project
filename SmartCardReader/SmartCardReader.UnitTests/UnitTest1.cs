using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.ServiceLayer.Implementation;
using Autofac;
using SmartCardReader.ServiceLayer.Base.Class;
using SmartCardReader.ServiceLayer.DI;

namespace SmartCardReader.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private static IContainer Container { get; set; }
        [TestMethod]
        public void TestMethod1()
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
    }
}