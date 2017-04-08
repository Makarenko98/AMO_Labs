using System;
using AMO_Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AMO_Lab2_Test
{
    [TestClass]
    public class SortInfoTest
    {
        [TestMethod]
        public void SortInfoPropTest()
        {
            MyArray<int>[] myArrs = new MyArray<int>[] {
                new MyArray<int>(new int[] { 2, 5, 3, 2, 6 }),
                new MyArray<int>(new int[] { 2, 4, 12, 88 }),
                new MyArray<int>(new int[] { 2, 6, 9, 11, 4, 6 }),
                new MyArray<int>(new int[] { 1, 2, 3, 1, 7, 88 })
            };
            SortInfo<int> sort = new SortInfo<int>(myArrs);
            if (sort.Arrays.Count != 4)
                Assert.Fail();
            for (int i = 0; i < myArrs.Length; i++)
                for (int j = 0; j < myArrs[i].Length; j++)
                    if (myArrs[i][j] != sort.Arrays[i][j])
                        Assert.Fail();
        }
    }
}
