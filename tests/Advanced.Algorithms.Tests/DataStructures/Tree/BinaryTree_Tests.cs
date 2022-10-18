﻿using System;
using System.Linq;
using Advanced.Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.DataStructures
{
    [TestClass]
    public class BinaryTreeTests
    {
        /// <summary>
        ///     A tree test
        /// </summary>
        [TestMethod]
        public void BinaryTree_Test()
        {
            var tree = new BinaryTree<int>();
            Assert.AreEqual(tree.GetHeight(), -1);

            tree.Insert(0, 0);
            Assert.AreEqual(tree.GetHeight(), 0);

            tree.Insert(0, 1);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Insert(0, 2);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Insert(1, 3);
            Assert.AreEqual(tree.GetHeight(), 2);

            try
            {
                tree.Delete(0);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.StartsWith("Cannot delete two child node"));
            }

            //IEnumerable test using linq count()
            Assert.AreEqual(tree.Count, tree.Count());

            Assert.AreEqual(tree.GetHeight(), 2);

            tree.Delete(1);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Delete(3);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Delete(2);
            Assert.AreEqual(tree.GetHeight(), 0);

            tree.Delete(0);
            Assert.AreEqual(tree.GetHeight(), -1);

            tree.Insert(0, 0);
            Assert.AreEqual(tree.GetHeight(), 0);

            tree.Insert(0, 1);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Insert(0, 2);
            Assert.AreEqual(tree.GetHeight(), 1);

            tree.Insert(1, 3);
            Assert.AreEqual(tree.GetHeight(), 2);

            //IEnumerable test using linq count()
            Assert.AreEqual(tree.Count, tree.Count());
        }
    }
}