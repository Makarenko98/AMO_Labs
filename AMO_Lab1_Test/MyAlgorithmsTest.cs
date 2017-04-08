using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMO_Lab1;

namespace AMO_Lab1_Test
{
    [TestClass]
    public class MyAlgorithmsTest
    {
        [TestMethod]
        public void Linear_5and3_12returned()
        {
            double a = 5;
            double c = 3;
            double delta = 0.07;
            double expected = 12.2857142;
            double actual = MyAlgorithms.Linear(a, c);
            Assert.AreEqual(expected, actual, delta);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Linear_Exception()
        {
            double a = -5;
            double c = 3;
            double delta = 0.07;
            double actual = MyAlgorithms.Linear(a, c);
        }

        [TestMethod]
        public void Branched_1_2_3_4()
        {
            double x = 1;
            double b = 2;
            double c = 3;
            double k = 4;
            double expect = 9;
            double actual = MyAlgorithms.Branched(x, b, c, k);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void CycleTest()
        {
            double[] mas = new double[] { 2, 3, 4, 5, 6, 7 };
            double expect = 30379;
            double actual = MyAlgorithms.Cyclic(mas);
            Assert.AreEqual(expect, actual);
        }
    }
}
