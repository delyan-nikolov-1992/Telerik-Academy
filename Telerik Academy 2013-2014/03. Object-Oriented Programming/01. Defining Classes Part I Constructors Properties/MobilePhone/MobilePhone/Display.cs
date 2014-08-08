namespace MobilePhone
{
    using System;
    using System.Text;

    public class Display
    {
        private float? size;
        private uint? numberOfColors;

        // contructors
        public Display(float? size, uint? numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public Display(float? size)
            : this(size, null)
        {

        }

        // properties
        public float? Size
        {
            get { return this.size; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The size of the display must be positive!");
                }

                this.size = value;
            }
        }

        public uint? NumberOfColors
        {
            get { return this.numberOfColors; }
            set { this.numberOfColors = value; }
        }

        // string representation of this object
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Display:");
            result.AppendLine("Size: " + (this.size == null ? "unknown" : (this.size.ToString() + " cm.")));
            result.AppendLine("Number of Colors: " + (this.numberOfColors == null ? "unknown" : this.numberOfColors.ToString()));

            return result.ToString();
        }
    }
}