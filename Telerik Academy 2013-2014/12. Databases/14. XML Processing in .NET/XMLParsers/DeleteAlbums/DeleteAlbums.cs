namespace DeleteAlbums
{
    using System.Collections.Generic;
    using System.Xml;

    public class DeleteAlbums
    {
        private const decimal MinPriceOfAlbum = 20;

        public static void Main()
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            XmlNode albumsList = catalog.DocumentElement;

            DeleteAlbumsByPrice(albumsList, MinPriceOfAlbum);

            catalog.Save("../../catalog.xml");
        }

        private static void DeleteAlbumsByPrice(XmlNode albumsList, decimal minPrice)
        {
            var albumsToDelete = new List<XmlNode>();

            foreach (XmlNode album in albumsList.ChildNodes)
            {
                decimal price = decimal.Parse(album["price"].InnerText);

                if (price > minPrice)
                {
                    albumsToDelete.Add(album);
                }
            }

            foreach (var album in albumsToDelete)
            {
                album.ParentNode.RemoveChild(album);
            }
        }
    }
}