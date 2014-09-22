namespace ImplementingHashTable
{
    using System;

    public class TestHashTable
    {
        public static void Main()
        {
            var hashTable = new HashTable<int, string>();

            hashTable.Add(1, "Test Add");
            hashTable[2] = "Test with index";

            var indexCheck = hashTable[2];

            Console.WriteLine("HashTable:");
            Console.WriteLine(hashTable);

            Console.WriteLine("\nindexer:");
            Console.WriteLine(hashTable[2]);
            Console.WriteLine(indexCheck);

            Console.WriteLine("\nkeys:");
            var keysChecker = hashTable.Keys;

            foreach (var key in keysChecker)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\ncount:");
            Console.WriteLine(hashTable.Count);
            Console.WriteLine("\nremove:");
            hashTable.Remove(4);

            Console.WriteLine(hashTable[2]);

            hashTable.Remove(2);

            Console.WriteLine(hashTable[2]);
            Console.WriteLine("\ncount:");
            Console.WriteLine(hashTable.Count);

            string res = hashTable.Find(1);
            Console.WriteLine("\nFind value by key 1:");
            Console.WriteLine(res);

            Console.WriteLine(hashTable);
            Console.WriteLine("\nclear");
            hashTable.Clear();
            Console.WriteLine(hashTable);
            Console.WriteLine("\nresize");

            for (int i = 0; i < 30; i++)
            {
                hashTable.Add(i, i.ToString());
            }

            Console.WriteLine(hashTable);
        }
    }
}