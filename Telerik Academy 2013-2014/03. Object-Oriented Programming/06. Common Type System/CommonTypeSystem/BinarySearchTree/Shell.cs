namespace BinarySearchTree
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                // Initialize a BST which will contain integers
                BinarySearchTree<int> intTree = new BinarySearchTree<int>();
                Random randomGen = new Random(DateTime.Now.Millisecond);
                string trace = "";

                // Insert 5 random integers into the tree
                for (int i = 0; i < 5; i++)
                {
                    int randomInt = randomGen.Next(1, 500);
                    intTree.Insert(randomInt);
                    trace += randomInt + " ";
                }

                // Find the largest value in the tree
                Console.WriteLine("Max: " + intTree.FindMax());

                // Find the smallest value in the tree
                Console.WriteLine("Min: " + intTree.FindMin());

                // Find the root of the tree
                Console.WriteLine("Root: " + intTree.Root.Element);

                // The order in which the elements were added to the tree
                Console.WriteLine("Trace: " + trace);

                // A textual representation of the tree
                Console.WriteLine("Tree: " + intTree);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}