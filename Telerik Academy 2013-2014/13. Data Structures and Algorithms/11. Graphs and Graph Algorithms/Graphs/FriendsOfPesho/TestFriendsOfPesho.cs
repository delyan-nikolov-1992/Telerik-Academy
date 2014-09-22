namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;

    public class TestFriendsOfPesho
    {
        public static void Main()
        {
            string[] counters = Console.ReadLine().Split(' ');

            int streetsCount = int.Parse(counters[1]);

            string[] hospitals = Console.ReadLine().Split(' ');

            var uniqueNodes = new Dictionary<int, Node>();
            var graph = new Dictionary<Node, List<Connection>>();

            for (int i = 0; i < streetsCount; i++)
            {
                string[] connection = Console.ReadLine().Split(' ');

                int firstNode = int.Parse(connection[0]);
                int secondNode = int.Parse(connection[1]);
                int distance = int.Parse(connection[2]);

                if (!uniqueNodes.ContainsKey(firstNode))
                {
                    Node firstUniqueNode = new Node(firstNode);
                    uniqueNodes.Add(firstNode, firstUniqueNode);
                }

                if (!uniqueNodes.ContainsKey(secondNode))
                {
                    Node secondUniqueNode = new Node(secondNode);
                    uniqueNodes.Add(secondNode, secondUniqueNode);
                }

                if (!graph.ContainsKey(uniqueNodes[firstNode]))
                {
                    graph.Add(uniqueNodes[firstNode], new List<Connection>());
                }

                if (!graph.ContainsKey(uniqueNodes[secondNode]))
                {
                    graph.Add(uniqueNodes[secondNode], new List<Connection>());
                }

                graph[uniqueNodes[firstNode]].Add(new Connection(uniqueNodes[secondNode], distance));
                graph[uniqueNodes[secondNode]].Add(new Connection(uniqueNodes[firstNode], distance));
            }

            var allHospitals = new List<int>();

            for (int i = 0; i < hospitals.Length; i++)
            {
                int someHospital = int.Parse(hospitals[i]);
                allHospitals.Add(someHospital);
                uniqueNodes[someHospital].IsHospital = true;
            }

            int minDijkstra = int.MaxValue;

            for (int i = 0; i < allHospitals.Count; i++)
            {
                DijkstraAlgorithm(graph, uniqueNodes[allHospitals[i]]);

                int sum = 0;

                foreach (var item in uniqueNodes)
                {
                    if (!item.Value.IsHospital)
                    {
                        sum += item.Value.DijkstraDistance;
                    }
                }

                if (sum < minDijkstra)
                {
                    minDijkstra = sum;
                }
            }

            Console.WriteLine(minDijkstra);
        }

        private static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var item in graph)
            {
                item.Key.DijkstraDistance = int.MaxValue;
            }

            queue.Enqueue(source);
            source.DijkstraDistance = 0;

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var connection in graph[currentNode])
                {
                    var potDistance = connection.Distance + currentNode.DijkstraDistance;

                    if (potDistance < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = potDistance;
                        queue.Enqueue(connection.ToNode);
                    }
                }
            }
        }
    }
}