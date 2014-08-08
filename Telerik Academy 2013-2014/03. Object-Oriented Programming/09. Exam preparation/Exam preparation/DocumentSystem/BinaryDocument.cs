namespace DocumentSystem
{
    using System.Collections.Generic;

    public class BinaryDocument : Document, IDocument
    {
        public uint? Size { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("size"))
            {
                this.Size = uint.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }
    }
}