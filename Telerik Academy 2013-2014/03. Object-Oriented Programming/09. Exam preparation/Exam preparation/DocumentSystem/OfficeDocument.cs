namespace DocumentSystem
{
    using System.Collections.Generic;

    public class OfficeDocument : BinaryDocument, IDocument
    {
        public string Version { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("version"))
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }
    }
}