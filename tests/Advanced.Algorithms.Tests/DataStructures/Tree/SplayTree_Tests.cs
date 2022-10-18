﻿using System;
using System.Linq;
using Advanced.Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.DataStructures
{
    [TestClass]
    public class SplayTreeTests
    {
        /// <summary>
        ///     A tree test
        /// </summary>
        [TestMethod]
        public void SplayTree_Smoke_Test()
        {
            //insert test
            var tree = new SplayTree<int>();

            tree.Insert(11);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(19);
            tree.Insert(4);
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(17);
            tree.Insert(43);
            tree.Insert(49);
            tree.Insert(31);

            //IEnumerable test using linq
            Assert.AreEqual(tree.Count, tree.Count());

            //delete
            tree.Delete(43);
            tree.Delete(11);
            tree.Delete(6);
            tree.Delete(8);
            tree.Delete(19);
            tree.Delete(4);
            tree.Delete(10);
            tree.Delete(5);
            tree.Delete(17);
            tree.Delete(49);
            tree.Delete(31);

            Assert.AreEqual(tree.Count, 0);

            tree.Insert(31);
        }


        [TestMethod]
        public void SplayTree_BulkInit_Test()
        {
            var nodeCount = 1000;

            var rnd = new Random();
            var sortedNumbers = Enumerable.Range(1, nodeCount).ToList();

            var tree = new SplayTree<int>(sortedNumbers);

            Assert.IsTrue(tree.Root.IsBinarySearchTree(int.MinValue, int.MaxValue));
            Assert.AreEqual(tree.Count, tree.Count());
            tree.Root.VerifyCount();

            for (var i = 0; i < nodeCount; i++)
            {
                Assert.IsTrue(tree.Root.IsBinarySearchTree(int.MinValue, int.MaxValue));
                tree.Delete(sortedNumbers[i]);
                Assert.IsTrue(tree.Count == nodeCount - 1 - i);
            }

            Assert.IsTrue(tree.Count == 0);
        }

        [TestMethod]
        public void SplayTree_Accuracy_Test()
        {
            var nodeCount = 1000;

            var rnd = new Random();
            var sorted = Enumerable.Range(1, nodeCount).ToList();
            var randomNumbers = sorted
                .OrderBy(x => rnd.Next())
                .ToList();

            var tree = new SplayTree<int>();

            for (var i = 0; i < nodeCount; i++)
            {
                tree.Insert(randomNumbers[i]);
                tree.Root.VerifyCount();
                Assert.IsTrue(tree.Count == i + 1);
            }

            for (var i = 0; i < sorted.Count; i++)
            {
                Assert.AreEqual(sorted[i], tree.ElementAt(i));
                Assert.AreEqual(i, tree.IndexOf(sorted[i]));
            }

            //shuffle again before deletion tests
            randomNumbers = Enumerable.Range(1, nodeCount)
                .OrderBy(x => rnd.Next())
                .ToList();

            //IEnumerable test using linq
            Assert.AreEqual(tree.Count, tree.Count());
            Assert.AreEqual(tree.Count, tree.AsEnumerableDesc().Count());

            for (var i = 0; i < nodeCount; i++)
            {
                if (rnd.NextDouble() >= 0.5)
                {
                    tree.Delete(randomNumbers[i]);
                }
                else
                {
                    var index = tree.IndexOf(randomNumbers[i]);
                    Assert.AreEqual(tree.ElementAt(index), randomNumbers[i]);
                    tree.RemoveAt(index);
                }

                tree.Root.VerifyCount();
                Assert.IsTrue(tree.Count == nodeCount - 1 - i);
            }

            Assert.IsTrue(tree.Count == 0);
        }

        [TestMethod]
        public void SplayTree_Stress_Test()
        {
            var nodeCount = 1000 * 10;

            var rnd = new Random();
            var randomNumbers = Enumerable.Range(1, nodeCount)
                .OrderBy(x => rnd.Next())
                .ToList();

            var tree = new SplayTree<int>();

            for (var i = 0; i < nodeCount; i++)
            {
                tree.Insert(randomNumbers[i]);
                Assert.IsTrue(tree.Count == i + 1);
            }

            //shuffle again before deletion tests
            randomNumbers = Enumerable.Range(1, nodeCount)
                .OrderBy(x => rnd.Next())
                .ToList();

            //IEnumerable test using linq
            Assert.AreEqual(tree.Count, tree.Count());

            for (var i = 0; i < nodeCount; i++)
            {
                tree.Delete(randomNumbers[i]);
                Assert.IsTrue(tree.Count == nodeCount - 1 - i);
            }

            Assert.IsTrue(tree.Count == 0);
        }
    }
}