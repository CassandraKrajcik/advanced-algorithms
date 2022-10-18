﻿using System;
using System.Linq;
using Advanced.Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.DataStructures
{
    [TestClass]
    public class BinomialHeapTests
    {
        [TestMethod]
        public void Min_BinomialHeap_Test()
        {
            var nodeCount = 1000 * 10;

            var minHeap = new BinomialHeap<int>();

            for (var i = 0; i <= nodeCount; i++) minHeap.Insert(i);

            for (var i = 0; i <= nodeCount; i++) minHeap.UpdateKey(i, i - 1);
            var min = 0;
            for (var i = 0; i <= nodeCount; i++)
            {
                min = minHeap.Extract();
                Assert.AreEqual(min, i - 1);
            }

            //IEnumerable tests.
            Assert.AreEqual(minHeap.Count, minHeap.Count());

            var rnd = new Random();
            var testSeries = Enumerable.Range(0, nodeCount - 1).OrderBy(x => rnd.Next()).ToList();

            foreach (var item in testSeries) minHeap.Insert(item);

            for (var i = 0; i < testSeries.Count; i++)
            {
                var decremented = testSeries[i] - rnd.Next(0, 1000);
                minHeap.UpdateKey(testSeries[i], decremented);
                testSeries[i] = decremented;
            }

            testSeries.Sort();

            for (var i = 0; i < nodeCount - 2; i++)
            {
                min = minHeap.Extract();
                Assert.AreEqual(testSeries[i], min);
            }

            //IEnumerable tests.
            Assert.AreEqual(minHeap.Count, minHeap.Count());
        }


        [TestMethod]
        public void Max_BinomialHeap_Test()
        {
            var nodeCount = 1000 * 10;

            var tree = new BinomialHeap<int>(SortDirection.Descending);

            for (var i = 0; i <= nodeCount; i++) tree.Insert(i);

            for (var i = 0; i <= nodeCount; i++) tree.UpdateKey(i, i + 1);
            var max = 0;
            for (var i = nodeCount; i >= 0; i--)
            {
                max = tree.Extract();
                Assert.AreEqual(max, i + 1);
            }

            //IEnumerable tests.
            Assert.AreEqual(tree.Count, tree.Count());

            var rnd = new Random();
            var testSeries = Enumerable.Range(0, nodeCount - 1).OrderBy(x => rnd.Next()).ToList();

            foreach (var item in testSeries) tree.Insert(item);

            for (var i = 0; i < testSeries.Count; i++)
            {
                var incremented = testSeries[i] + rnd.Next(0, 1000);
                tree.UpdateKey(testSeries[i], incremented);
                testSeries[i] = incremented;
            }

            testSeries = testSeries.OrderByDescending(x => x).ToList();

            for (var i = 0; i < nodeCount - 2; i++)
            {
                max = tree.Extract();
                Assert.AreEqual(testSeries[i], max);
            }

            //IEnumerable tests.
            Assert.AreEqual(tree.Count, tree.Count());
        }
    }
}