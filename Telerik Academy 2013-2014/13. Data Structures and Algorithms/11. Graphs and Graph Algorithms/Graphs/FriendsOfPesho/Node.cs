namespace FriendsOfPesho
{
    using System;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.ID = id;
            this.IsHospital = false;
        }

        public int ID { get; private set; }

        public int DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}