//3. Card Wars from Telerik Academy Exam 1 @ 24 June 2013 Evening

using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        int games = int.Parse(Console.ReadLine());
        int counter = 0;
        string currentCard;
        int firstPlayerHand = 0;
        int secondPlayerHand = 0;
        int currentPlayerHand = firstPlayerHand;
        BigInteger firstPlayerScore = 0;
        BigInteger secondPlayerScore = 0;
        int firstPlayerGames = 0;
        int secondPlayerGames = 0;
        int xCardDrawn = 0;

        for (int i = 0; i < games; i++)
        {
            while (counter < 6)
            {
                if (counter == 3)
                {
                    firstPlayerHand += currentPlayerHand;
                    currentPlayerHand = secondPlayerHand;
                }

                currentCard = Console.ReadLine();

                switch (currentCard)
                {
                    case "2":
                        currentPlayerHand += 10;
                        break;
                    case "3":
                        currentPlayerHand += 9;
                        break;
                    case "4":
                        currentPlayerHand += 8;
                        break;
                    case "5":
                        currentPlayerHand += 7;
                        break;
                    case "6":
                        currentPlayerHand += 6;
                        break;
                    case "7":
                        currentPlayerHand += 5;
                        break;
                    case "8":
                        currentPlayerHand += 4;
                        break;
                    case "9":
                        currentPlayerHand += 3;
                        break;
                    case "10":
                        currentPlayerHand += 2;
                        break;
                    case "A":
                        currentPlayerHand += 1;
                        break;
                    case "J":
                        currentPlayerHand += 11;
                        break;
                    case "Q":
                        currentPlayerHand += 12;
                        break;
                    case "K":
                        currentPlayerHand += 13;
                        break;
                    case "Z":
                        if (counter < 3)
                        {
                            firstPlayerScore *= 2;
                        }
                        else
                        {
                            secondPlayerScore *= 2;
                        }
                        break;
                    case "Y":
                        if (counter < 3)
                        {
                            firstPlayerScore -= 200;
                        }
                        else
                        {
                            secondPlayerScore -= 200;
                        }
                        break;
                    case "X":
                        if (xCardDrawn == 0)
                        {
                            if (counter < 3)
                            {
                                xCardDrawn = 1;
                            }
                            else
                            {
                                xCardDrawn = 2;
                            }
                        }
                        else
                        {
                            xCardDrawn = 3;
                        }

                        break;
                }

                counter++;
            }

            if (xCardDrawn == 1)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                break;
            }
            else if (xCardDrawn == 2)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                break;
            }
            else if (xCardDrawn == 3)
            {
                firstPlayerScore += 50;
                secondPlayerScore += 50;
                xCardDrawn = 0;
            }

            secondPlayerHand += currentPlayerHand;

            if (firstPlayerHand > secondPlayerHand)
            {
                firstPlayerScore += firstPlayerHand;
                firstPlayerGames++;
            }
            else if (firstPlayerHand < secondPlayerHand)
            {
                secondPlayerScore += secondPlayerHand;
                secondPlayerGames++;
            }

            firstPlayerHand = 0;
            secondPlayerHand = 0;
            currentPlayerHand = firstPlayerHand;
            counter = 0;
        }

        if (xCardDrawn == 0)
        {
            if (firstPlayerScore > secondPlayerScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: " + firstPlayerScore);
                Console.WriteLine("Games won: " + firstPlayerGames);
            }
            else if (firstPlayerScore < secondPlayerScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: " + secondPlayerScore);
                Console.WriteLine("Games won: " + secondPlayerGames);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: " + firstPlayerScore);
            }
        }
    }
}