namespace CreateAlbum
{
    using System.Text;
    using System.Xml;

    public class CreateAlbum
    {
        public static void Main()
        {
            var reader = XmlReader.Create("../../../catalog.xml");
            var writer = new XmlTextWriter("../../album.xml", Encoding.Unicode);

            using (reader)
            {
                using (writer)
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if (reader.Name.Equals("album") && reader.IsStartElement())
                        {
                            writer.WriteStartElement("album");

                            reader.ReadToDescendant("name");

                            string albumName = reader.ReadElementContentAsString();

                            reader.ReadToNextSibling("artist");

                            string authorName = reader.ReadElementContentAsString();

                            writer.WriteElementString("name", albumName);
                            writer.WriteElementString("author", authorName);

                            writer.WriteEndElement();
                        }
                    }
                }
            }
        }
    }
}