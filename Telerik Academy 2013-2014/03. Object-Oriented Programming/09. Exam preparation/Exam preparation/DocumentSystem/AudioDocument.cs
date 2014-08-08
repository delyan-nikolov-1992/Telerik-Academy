namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class AudioDocument : MultimediaDocument, IDocument
    {
        private float? sampleRate;

        public float? SampleRate
        {
            get
            {
                return this.sampleRate;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The sample rate of the audio document can not be negative!");
                }

                this.sampleRate = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("samplerate"))
            {
                this.sampleRate = float.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.sampleRate));
        }
    }
}