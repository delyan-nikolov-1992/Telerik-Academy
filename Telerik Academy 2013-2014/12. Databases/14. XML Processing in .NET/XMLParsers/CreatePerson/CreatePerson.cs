namespace CreatePerson
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class CreatePerson
    {
        public static void Main()
        {
            var textReader = new StreamReader("../../person.txt");
            var xmlWriter = new XmlTextWriter("../../person.xml", Encoding.Unicode);

            using (textReader)
            {
                string[] infos = textReader.ReadToEnd().Split(
                    new string[] 
                    { 
                        Environment.NewLine 
                    },
                    StringSplitOptions.RemoveEmptyEntries);

                using (xmlWriter)
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("person");
                    xmlWriter.WriteElementString("name", infos[0]);
                    xmlWriter.WriteElementString("address", infos[1]);
                    xmlWriter.WriteElementString("phone", infos[2]);
                    xmlWriter.WriteEndElement();
                }
            }
        }
    }
}