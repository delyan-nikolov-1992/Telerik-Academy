namespace Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class CountAlbums
    {
        public static void Main()
        {
            XmlDocument catalogDocument = new XmlDocument();
            catalogDocument.Load("../../../catalog.xml");

            XmlNode albumsList = catalogDocument.DocumentElement;

            var artistsAlbums = CountAllAlbums(albumsList);
            Print(artistsAlbums);
        }

        private static IDictionary<string, int> CountAllAlbums(XmlNode albumsList)
        {
            IDictionary<string, int> artistsAlbums = new Dictionary<string, int>();

            foreach (XmlNode album in albumsList.ChildNodes)
            {
                string artist = album["artist"].InnerText;
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