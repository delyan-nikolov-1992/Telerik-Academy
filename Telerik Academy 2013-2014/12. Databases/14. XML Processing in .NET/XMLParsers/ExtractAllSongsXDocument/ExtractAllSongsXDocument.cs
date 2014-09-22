namespace ExtractAllSongsXDocument
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractAllSongsXDocument
    {
        public static void Main()
        {
            XDocument catalog = XDocument.Load("../../../catalog.xml");

            var songs = catalog.Descendants("songs")
                .Select(song => song.Descendants("title").First().Value)
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}