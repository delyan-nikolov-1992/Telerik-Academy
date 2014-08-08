namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class VideoDocument : MultimediaDocument, IDocument
    {
        private float? frameRate;

        public float? FrameRate
        {
            get
            {
                return this.frameRate;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The frame rate of the video document can not be negative!");
                }

                this.frameRate = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("framerate"))
            {
                this.frameRate = float.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.frameRate));
        }
    }
}