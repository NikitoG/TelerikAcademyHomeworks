//Problem 3. Correct brackets

//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).

using System;

class CheckBrackets
{
    static void Main()
    {
        Console.Write("Enter a expression: ");
        string expression = Console.ReadLine();
        int countBracket = 0;
        foreach (var ch in expression)
        {
            if (ch == '(')
            {
                ++countBracket;
            }
            if (ch == ')')
            {
                --countBracket;
            }
            if (countBracket < 0)
            {
                Console.WriteLine("The brackets aren't put correctly!");
                return;
            }
        }
        if (countBracket == 0)
        {
            Console.WriteLine("The brackets are put correctly!");
        }
        else
        {
            Console.WriteLine("The brackets aren't put correctly!");
        }
    }
}

