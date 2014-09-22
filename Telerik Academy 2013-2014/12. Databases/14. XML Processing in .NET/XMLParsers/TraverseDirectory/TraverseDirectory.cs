namespace TraverseDirectory
{
    using System.IO;
    using System.Text;
    using System.Xml;

    public class TraverseDirectory
    {
        public static void Main()
        {
            var initialDirectory = "../../";

            var writer = new XmlTextWriter("../../directoryContent.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                writer.WriteStartDocument();

                AddDirectory(initialDirectory, writer);
            }
        }

        private static void AddDirectory(string directory, XmlTextWriter writer)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);

            writer.WriteStartElement("dir");
            var directoryName = directory.Split(new char[] { '\\' });
            writer.WriteAttributeString("name", directoryName[directoryName.Length - 1]);

            foreach (var subDirectory in subDirectories)
            {
                AddDirectory(subDirectory, writer);
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Split(new char[] { '\\' });
                writer.WriteElementString("file", fileName[fileName.Length - 1]);
            }

            writer.WriteEndElement();
        }
    }
}