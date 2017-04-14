using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMO_Lab4;

namespace AMO_Lab4_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewton()
        {
            Assert.AreEqual(4.907, MyAlgorithm.Newton(MyAlgorithm.Func, MyAlgorithm.dFunc, MyAlgorithm.ddFunc, 2, 6, 0.000000001), 0.001);
        }
    }
}
