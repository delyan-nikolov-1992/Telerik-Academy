namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Document : IDocument
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the document can not be null or empty!");
                }

                this.name = value;
            }
        }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key.Equals("name"))
            {
                this.name = value;
            }
            else if (key.Equals("content"))
            {
                this.Content = value;
            }
            else
            {
                throw new ArgumentException(string.Format("There is no key with the name: {0}", key));
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            bool first = true;

            this.SaveAllProperties(properties);
            properties.Sort((k, v) => k.Key.CompareTo(v.Key));
            result.Append(this.GetType().Name);
            result.Append("[");

            foreach (var currentProperty in properties)
            {
                if (currentProperty.Value != null)
                {
                    if (!first)
                    {
                        result.Append(";");
                    }

                    result.AppendFormat("{0}={1}", currentProperty.Key, currentProperty.Value);
                    first = false;
                }
            }

            result.Append("]");

            return result.ToString();
        }
    }
}