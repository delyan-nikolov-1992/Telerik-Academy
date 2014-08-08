namespace Substring
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int length)
        {
            if (index < 0 || index >= builder.Length)
            {
                throw new IndexOutOfRangeException("The start index was out of the range!");
            }

            if (length < 0 || length >= builder.Length || index + length < 0 || index + length >= builder.Length)
            {
                throw new IndexOutOfRangeException("The length of the substring was out of the range!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = index; i < index + length; i++)
            {
                result.Append(builder[i]);
            }

            return result;
        }
    }
}