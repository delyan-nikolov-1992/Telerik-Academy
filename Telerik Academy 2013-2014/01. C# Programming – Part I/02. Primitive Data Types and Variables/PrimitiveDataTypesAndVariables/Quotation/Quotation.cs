using System;

class Quotation
{
    static void Main()
    {
        String withQuote = "The \"use\" of quotations causes difficulties.";
        String withoutQuote = "The use of quotations causes difficulties.";

        Console.WriteLine(withQuote + "\n" + withoutQuote);
    }
}