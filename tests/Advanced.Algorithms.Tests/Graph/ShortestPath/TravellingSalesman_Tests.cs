﻿using Advanced.Algorithms.DataStructures.Graph.AdjacencyList;
using Advanced.Algorithms.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.Graph
{
    /// <summary>
    ///     Problem details below
    ///     https://en.wikipedia.org/wiki/Travelling_salesman_problem
    /// </summary>
    [TestClass]
    public class TravellingSalesmanTests
    {
        [TestMethod]
        public void TravellingSalesman_AdjacencyListGraph_Smoke_Test()
        {
            var graph = new WeightedDiGraph<int, int>();

            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 15);
            graph.AddEdge(0, 3, 6);

            graph.AddEdge(1, 0, 2);
            graph.AddEdge(1, 2, 7);
            graph.AddEdge(1, 3, 3);

            graph.AddEdge(2, 0, 9);
            graph.AddEdge(2, 1, 6);
            graph.AddEdge(2, 3, 12);

            graph.AddEdge(3, 0, 10);
            graph.AddEdge(3, 1, 4);
            graph.AddEdge(3, 2, 8);

            var tsp = new TravellingSalesman<int, int>();
            Assert.AreEqual(21, tsp.FindMinWeight(graph, new TspShortestPathOperators()));
        }

        [TestMethod]
        public void TravellingSalesman_AdjacencyMatrixGraph_Smoke_Test()
        {
            var graph = new Algorithms.DataStructures.Graph.AdjacencyMatrix.WeightedDiGraph<int, int>();

            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 15);
            graph.AddEdge(0, 3, 6);

            graph.AddEdge(1, 0, 2);
            graph.AddEdge(1, 2, 7);
            graph.AddEdge(1, 3, 3);

            graph.AddEdge(2, 0, 9);
            graph.AddEdge(2, 1, 6);
            graph.AddEdge(2, 3, 12);

            graph.AddEdge(3, 0, 10);
            graph.AddEdge(3, 1, 4);
            graph.AddEdge(3, 2, 8);

            var tsp = new TravellingSalesman<int, int>();
            Assert.AreEqual(21, tsp.FindMinWeight(graph, new TspShortestPathOperators()));
        }
    }

    /// <summary>
    ///     generic operations for int type
    /// </summary>
    public class TspShortestPathOperators : IShortestPathOperators<int>
    {
        public int DefaultValue => 0;

        public int MaxValue => int.MaxValue;

        public int Sum(int a, int b)
        {
            return checked(a + b);
        }
    }
}