namespace DocumentSystem
{
    using System.Collections.Generic;

    public class ExcelDocument : OfficeDocument, IDocument, IEncryptable
    {
        public uint? Rows { get; private set; }

        public uint? Cols { get; private set; }

        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("rows"))
            {
                this.Rows = uint.Parse(value);
            }
            else if (key.Equals("cols"))
            {
                this.Cols = uint.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        }

        public override string ToString()
        {
            if (this.IsEncrypted)
            {
                return string.Format("{0}[encrypted]", this.GetType().Name);
            }
            else
            {
                return base.ToString();
            }
        }
    }
}