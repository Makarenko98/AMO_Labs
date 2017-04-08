using System;
using AMO_Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMO_Lab2_Test
{
    [TestClass]
    public class MyArrTest
    {

        [TestMethod]
        public void MyArrTestLength()
        {
            MyArray<int> myArr = new MyArray<int>(new int[] { 2, 5, 3, 4, 1 });
            Assert.AreEqual(5, myArr.Length);
        }

        [TestMethod]
        public void MyArrTestAdd()
        {
            int[] etArr = new int[] { 2, 5, 3, 4, 1 };
            MyArray<int> myArr = new MyArray<int>(etArr);
            myArr.Add(6);
            if (myArr.Length != 6)
                Assert.Fail();
            etArr = new int[] { 2, 5, 3, 4, 1, 6 };
            for (int i = 0; i < 6; i++)
            {
                if (myArr[i] != etArr[i])
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void MyArrTestGetArr()
        {
            int[] etArr = new int[] { 2, 5, 3, 4, 1 };
            MyArray<int> myArr = new MyArray<int>(etArr);
            int[] newArr = myArr.Array;
            if (newArr.Length != myArr.Length)
                Assert.Fail();
            for (int i = 0; i < 5; i++)
            {
                if (myArr[i] != etArr[i])
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void MyArrTestSort()
        {
            int[] etArr = new int[] { 2, 5, 3, 4, 1 };
            MyArray<int> myArr = new MyArray<int>(etArr);
            myArr.Sort();
            if (myArr.SortedArray.Length != etArr.Length)
                Assert.Fail();
            for (int i = 0; i < myArr.Length; i++)
            {
                if (myArr.SortedArray[i] != i + 1)
                    Assert.Fail();
            }
        }
    }
}
