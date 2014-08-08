namespace GenericList
{
    using System;

    public static class GenericListExtensions
    {
        public static T Min<T>(this GenericList<T> genericList) where T : IComparable<T>
        {
            if (genericList.Next == 0)
            {
                throw new ArgumentNullException("The list is empty!");
            }

            T min = genericList[0];

            for (int i = 1; i < genericList.Next; i++)
            {
                if (min.CompareTo(genericList[i]) > 0)
                {
                    min = genericList[i];
                }
            }

            return min;
        }

        public static T Max<T>(this GenericList<T> genericList) where T : IComparable
        {
            if (genericList.Next == 0)
            {
                throw new ArgumentNullException("The list is empty!");
            }

            T max = genericList[0];

            for (int i = 1; i < genericList.Next; i++)
            {
                if (max.CompareTo(genericList[i]) < 0)
                {
                    max = genericList[i];
                }
            }

            return max;
        }
    }
}