﻿using Advanced.Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.DataStructures
{
    [TestClass]
    public class SegmentTreeTests
    {
        /// <summary>
        ///     Smoke test
        /// </summary>
        [TestMethod]
        public void SegmentTree_Sum_Smoke_Test()
        {
            var testArray = new[] { 1, 3, 5, 7, 9, 11 };

            //tree with sum operation
            var tree = new SegmentTree<int>(testArray,
                (x, y) => x + y,
                () => 0);

            var sum = tree.RangeResult(1, 3);

            Assert.AreEqual(15, sum);
        }
    }
}