namespace GenericList
{
    using System;

    public class Test
    {
        private const int SIZE = 3;
        private const int SEARCHED_INT_VALUE = 2;
        private const string SEARCHED_STRING_VALUE = "Krasi";

        public static void Main()
        {
            try
            {
                // first test with ints
                GenericList<int> listInts = new GenericList<int>(SIZE);
                listInts.Add(3);
                listInts.Add(2);
                listInts.Add(-1);
                listInts.Add(4);
                Console.WriteLine(listInts.ToString());
                listInts.RemoveAt(2);
                Console.WriteLine(listInts.ToString());
                listInts.Insert(2, -1);
                Console.WriteLine(listInts.ToString());
                Console.WriteLine("The minimum element in the list is {0}", listInts.Min());
                Console.WriteLine("The maximum element in the list is {0}", listInts.Max());
                Console.WriteLine((listInts.FindElementIndex(SEARCHED_INT_VALUE) == -1 ? 
                    (string.Format("There is no such element in the list: {0}", SEARCHED_INT_VALUE))
                    : (string.Format("The element {0} is on position {1}", SEARCHED_INT_VALUE, listInts.FindElementIndex(SEARCHED_INT_VALUE)))));
                listInts.Clear();
                Console.WriteLine(listInts.ToString());

                // second test with strings
                GenericList<string> listStrings = new GenericList<string>(SIZE);
                listStrings.Add("Stefan");
                listStrings.Add("Boris");
                listStrings.Add("Maria");
                listStrings.Add("Boris");
                Console.WriteLine(listStrings.ToString());
                listStrings.RemoveAt(2);
                Console.WriteLine(listStrings.ToString());
                listStrings.Insert(2, "Maria");
                Console.WriteLine(listStrings.ToString());
                Console.WriteLine("The minimum element in the list is {0}", listStrings.Min());
                Console.WriteLine("The maximum element in the list is {0}", listStrings.Max());
                Console.WriteLine((listStrings.FindElementIndex(SEARCHED_STRING_VALUE) == -1 ?
                    (string.Format("There is no such element in the list: {0}", SEARCHED_STRING_VALUE))
                    : (string.Format("The element {0} is on position {1}", SEARCHED_STRING_VALUE, listStrings.FindElementIndex(SEARCHED_STRING_VALUE)))));
                listStrings.Clear();
                Console.Write(listStrings.ToString());
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}