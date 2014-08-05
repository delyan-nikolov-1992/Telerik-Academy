using System;

class CheckBrackets
{
    static void Main()
    {
        Console.Write("The given expression: ");
        string expression = Console.ReadLine();
        int brackets = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                brackets++;
            }
            else if (expression[i] == ')')
            {
                brackets--;
            }

            if (brackets < 0)
            {
                break;
            }
        }

        if (brackets == 0)
        {
            Console.WriteLine("The expression is valid.");
        }
        else
        {
            Console.WriteLine("The expression is invalid.");
        }
    }
}