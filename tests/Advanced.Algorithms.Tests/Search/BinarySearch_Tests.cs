﻿using Advanced.Algorithms.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.Search
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void Search_Smoke_Test()
        {
            var test = new[]
            {
                2, 3, 5, 7, 11, 13, 17, 19,
                23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79
            };

            Assert.AreEqual(15, BinarySearch.Search(test, 53));
            Assert.AreEqual(-1, BinarySearch.Search(test, 80));
        }
    }
}