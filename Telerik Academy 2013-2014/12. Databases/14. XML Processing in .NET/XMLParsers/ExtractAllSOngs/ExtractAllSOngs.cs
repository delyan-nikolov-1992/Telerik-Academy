namespace ExtractAllSOngs
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractAllSOngs
    {
        public static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                var songs = GetAllSongs(reader);
                PrintSongs(songs);
            }
        }

        private static IList<string> GetAllSongs(XmlReader reader)
        {
            var songs = new List<string>();

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "title"))
                {
                    songs.Add(reader.ReadElementString());
                }
            }

            return songs;
        }

        private static void PrintSongs(IList<string> songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}