using System;

class PrintCards
{
    static void Main()
    {
        string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] ranks = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", 
                                            "Jack", "Queen", "King", "Ace" };

        foreach (string currentSuit in suits)
        {
            foreach (string currentRank in ranks)
            {
                Console.WriteLine(currentRank + " of " + currentSuit);
            }

            Console.WriteLine();
        }
    }
}