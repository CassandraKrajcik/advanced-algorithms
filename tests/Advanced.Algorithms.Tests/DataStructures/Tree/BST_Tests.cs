﻿using System;
using System.Linq;
using Advanced.Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.DataStructures
{
    [TestClass]
    public class BST_Tests
    {
        /// <summary>
        ///     A tree test
        /// </summary>
        [TestMethod]
        public void BST_Test()
        {
            //insert test
            var tree = new BST<int>();
            Assert.AreEqual(tree.GetHeight(), -1);

            tree.Insert(11);
            Assert.AreEqual(tree.GetHeight(), 0);

            tree.Insert(6);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Insert(8);
            Assert.AreEqual(tree.GetHeight(), 2);

            tree.Insert(19);
            Assert.AreEqual(tree.GetHeight(), 2);

            tree.Insert(4);
            Assert.AreEqual(tree.GetHeight(), 2);

            tree.Insert(10);
            Assert.AreEqual(tree.GetHeight(), 3);

            tree.Insert(5);
            Assert.AreEqual(tree.GetHeight(), 3);

            tree.Insert(17);
            Assert.AreEqual(tree.GetHeight(), 3);

            tree.Insert(43);
            Assert.AreEqual(tree.GetHeight(), 3);

            tree.Insert(49);
            Assert.AreEqual(tree.GetHeight(), 3);

            tree.Insert(31);
            Assert.AreEqual(tree.GetHeight(), 3);

            Assert.IsTrue(tree.Root.IsBinarySearchTree(int.MinValue, int.MaxValue));

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

            Assert.AreEqual(tree.GetHeight(), -1);
            Assert.AreEqual(tree.Count, 0);

            tree.Insert(31);
        }

        [TestMethod]
        public void BST_BulkInit_Test()
        {
            var nodeCount = 1000;

            var rnd = new Random();
            var sortedNumbers = Enumerable.Range(1, nodeCount).ToList();

            var tree = new BST<int>(sortedNumbers);

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
        public void BST_Accuracy_Test()
        {
            var nodeCount = 1000;

            var rnd = new Random();
            var sorted = Enumerable.Range(1, nodeCount).ToList();
            var randomNumbers = sorted
                .OrderBy(x => rnd.Next())
                .ToList();

            var tree = new BST<int>();

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
        public void BST_Stress_Test()
        {
            var nodeCount = 1000 * 10;

            var rnd = new Random();
            var randomNumbers = Enumerable.Range(1, nodeCount)
                .OrderBy(x => rnd.Next())
                .ToList();

            var tree = new BST<int>();

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