namespace ImplementingBiDictionary
{
    using System;

    public class TestBiDictionary
    {
        public static void Main()
        {
            var bdict = new BiDictionary<string, string, string>();

            bdict.Add("Peter", "Petrov", "student");
            bdict.Add("Gosho", "Goshev", "engineer");
            bdict.Add("Minka", "Georgieva", "scientist");
            bdict.Add("Peter", "Goshev", "developer");

            Console.WriteLine("All people with firstname Peter: {0}", 
                string.Join(", ", bdict.GetByK1("Peter")));

            Console.WriteLine("All people with lastname Goshev: {0}", 
                string.Join(", ", bdict.GetByK2("Goshev")));

            Console.WriteLine("All people with fullname Peter Goshev: {0}", 
                string.Join(", ", bdict.GetByBoth("Peter", "Goshev")));
        }
    }
}