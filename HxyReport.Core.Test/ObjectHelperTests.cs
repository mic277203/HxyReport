using Microsoft.VisualStudio.TestTools.UnitTesting;
using HxyReport.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Core.Tests
{
    [TestClass()]
    public class ObjectHelperTests
    {
        [TestMethod()]
        public void ToSafeStringTest()
        {
            var m = ObjectHelper.ToSafeString(null);
            var m1 = ObjectHelper.ToSafeString("");
            var m2 = ObjectHelper.ToSafeString("test");
            Assert.AreEqual(m, "");
            Assert.AreEqual(m1, "");
            Assert.AreEqual(m2, "test");
        }
    }
}