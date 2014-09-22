namespace CountAlbumsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class CountAlbumsXPath
    {
        public static void Main()
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            string pathQuery = "/catalog/album";
            XmlNodeList albumsList = catalog.SelectNodes(pathQuery);

            var artistsAlbums = CountAllAlbums(albumsList);
            Print(artistsAlbums);
        }

        private static IDictionary<string, int> CountAllAlbums(XmlNodeList albumsList)
        {
            IDictionary<string, int> artistsAlbums = new Dictionary<string, int>();

            foreach (XmlNode album in albumsList)
            {
                string artist = album.SelectSingleNode("artist").InnerText;
                int count = 1;

                if (artistsAlbums.ContainsKey(artist))
                {
                    count = artistsAlbums[artist] + 1;
                }

                artistsAlbums[artist] = count;
            }

            return artistsAlbums;
        }

        private static void Print(IDictionary<string, int> artistsAlbums)
        {
            foreach (var pair in artistsAlbums)
            {
                Console.WriteLine("Artist: {0}; Albums: {1}", pair.Key, pair.Value);
            }
        }
    }
}