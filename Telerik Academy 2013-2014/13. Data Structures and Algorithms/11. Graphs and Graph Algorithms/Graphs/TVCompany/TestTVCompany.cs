﻿namespace TVCompany
{
    using System;
    using System.Collections.Generic;

    public class TestTVCompany
    {
        public static void Main()
        {
            var priority = new SortedSet<Edge>();
            int numberOfNodes = 6;
            var used = new bool[numberOfNodes + 1];
            var mpdNodes = new List<Edge>();
            var edges = new List<Edge>();
            InitializeGraph(edges);

            foreach (Edge edge in edges)
            {
                if (edge.StartNode == edges[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            used[edges[0].StartNode] = true;

            FindMinimumSpanningTree(used, priority, mpdNodes, edges);

            PrintMinimumSpanningTree(mpdNodes);
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> mpdNodes)
        {
            foreach (Edge edge in mpdNodes)
            {
                Console.WriteLine("{0}", edge);
            }
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> mpdEdges, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndNode])
                {
                    used[edge.EndNode] = true;
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(1, 4, 9));
            edges.Add(new Edge(2, 4, 2));
            edges.Add(new Edge(3, 4, 20));
            edges.Add(new Edge(3, 5, 7));
            edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(5, 6, 12));
        }
    }
}