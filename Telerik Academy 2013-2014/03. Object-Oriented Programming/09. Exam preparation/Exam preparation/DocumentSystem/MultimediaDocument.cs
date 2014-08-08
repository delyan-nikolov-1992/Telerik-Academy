namespace DocumentSystem
{
    using System.Collections.Generic;

    public class MultimediaDocument : BinaryDocument, IDocument
    {
        public uint? Length { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("length"))
            {
                this.Length = uint.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }
}