using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCardReader.DataAccessLayer.Concrete;

namespace SmartCardReader.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var _ctx = new EfDbContext();
            var result = _ctx.Courses.ToList();

        }
    }
}
