namespace FriendsOfPesho
{
    public class Connection
    {
        public Connection(Node node, int distance)
        {
            this.ToNode = node;
            this.Distance = distance;
        }

        public Node ToNode { get; set; }

        public int Distance { get; set; }
    }
}