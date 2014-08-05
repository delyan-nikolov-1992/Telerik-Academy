using System;

class HelloWorld
{
    static void Main()
    {
        String firstWord = "Hello";
        String secondWord = "World";
        object concatenation = firstWord + " " + secondWord;
        String thirdWord = (String)concatenation;

        Console.WriteLine(thirdWord);
    }
}