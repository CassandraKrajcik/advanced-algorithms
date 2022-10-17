﻿using System.Collections.Generic;
using System.Linq;
using Advanced.Algorithms.DataStructures.Graph.AdjacencyList;
using Advanced.Algorithms.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.Graph
{
    [TestClass]
    public class TarjansStronglyConnected_Tests
    {
        [TestMethod]
        public void TarjanStronglyConnected_AdjancencyListGraph_Smoke_Test()
        {
            var graph = new DiGraph<char>();

            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');
            graph.AddVertex('F');
            graph.AddVertex('G');
            graph.AddVertex('H');


            graph.AddEdge('A', 'B');
            graph.AddEdge('B', 'C');
            graph.AddEdge('C', 'A');

            graph.AddEdge('C', 'D');
            graph.AddEdge('D', 'E');

            graph.AddEdge('E', 'F');
            graph.AddEdge('F', 'G');
            graph.AddEdge('G', 'E');

            graph.AddEdge('F', 'H');

            var algorithm = new TarjansStronglyConnected<char>();

            var result = algorithm.FindStronglyConnectedComponents(graph);

            Assert.AreEqual(4, result.Count);

            var expectedResult = new List<List<char>>
            {
                new[] { 'H' }.ToList(),
                new[] { 'E', 'F', 'G' }.ToList(),
                new[] { 'D' }.ToList(),
                new[] { 'A', 'B', 'C' }.ToList()
            };

            for (var i = 0; i < expectedResult.Count; i++)
            {
                var expectation = expectedResult[i];
                var actual = result[i];

                Assert.IsTrue(expectation.Count == actual.Count);

                foreach (var vertex in expectation) Assert.IsTrue(actual.Contains(vertex));
            }
        }

        [TestMethod]
        public void TarjanStronglyConnected_AdjancencyMatrixGraph_Smoke_Test()
        {
            var graph = new Algorithms.DataStructures.Graph.AdjacencyMatrix.DiGraph<char>();

            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');
            graph.AddVertex('F');
            graph.AddVertex('G');
            graph.AddVertex('H');


            graph.AddEdge('A', 'B');
            graph.AddEdge('B', 'C');
            graph.AddEdge('C', 'A');

            graph.AddEdge('C', 'D');
            graph.AddEdge('D', 'E');

            graph.AddEdge('E', 'F');
            graph.AddEdge('F', 'G');
            graph.AddEdge('G', 'E');

            graph.AddEdge('F', 'H');

            var algorithm = new TarjansStronglyConnected<char>();

            var result = algorithm.FindStronglyConnectedComponents(graph);

            Assert.AreEqual(4, result.Count);

            var expectedResult = new List<List<char>>
            {
                new[] { 'H' }.ToList(),
                new[] { 'E', 'F', 'G' }.ToList(),
                new[] { 'D' }.ToList(),
                new[] { 'A', 'B', 'C' }.ToList()
            };

            for (var i = 0; i < expectedResult.Count; i++)
            {
                var expectation = expectedResult[i];
                var actual = result[i];

                Assert.IsTrue(expectation.Count == actual.Count);

                foreach (var vertex in expectation) Assert.IsTrue(actual.Contains(vertex));
            }
        }
    }
}