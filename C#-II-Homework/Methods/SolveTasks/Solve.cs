//Problem 13. Solve tasks

//Write a program that can solve these tasks:

//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0

//Create appropriate methods.
//Provide a simple text-based menu for the user to choose which task to solve.
//Validate the input data:

//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;

class Solve
{
    static void Main()
    {
        Console.WriteLine("Press : ");
        Console.WriteLine(" 1 - For reverses the digits of a number press!");
        Console.WriteLine(" 2 - For calculates the average of a sequence of integers!");
        Console.WriteLine(" 3 - For solves a linear equation a * x + b = 0!");

        int choice = int.Parse(Console.ReadLine());

        int reverse = 0;
        switch (choice)
        {
            case 1:
                RevesreNumber();
                break;
            case 2:
                AverageOfASequence();
                break;
            case 3:
                LinearEquation();
                break;
            default:
                Console.WriteLine("Wrong input!");
                break;
        }
    }

    static void RevesreNumber()
    {
        Console.Clear();
        decimal number;
        do
        {
            Console.Write("Enter non-negative number: ");
        } while (!(decimal.TryParse(Console.ReadLine(), out number) && number >= 0));

        string inputNumber = number.ToString();
        char[] charNumber = inputNumber.ToCharArray();
        char[] charReverse = new char[charNumber.Length];
        for (int i = 0; i < charNumber.Length; i++)
        {
            charReverse[charReverse.Length - 1 - i] = charNumber[i];
        }
        string stringReverse = new string(charReverse);
        decimal reverse = decimal.Parse(stringReverse);

        Console.Clear();
        Console.WriteLine("{0} -> reverse -> {1}", number, reverse);
    }

    static void AverageOfASequence()
    {
        Console.Clear();
        string input = string.Empty;
        do
        {
            Console.Write("Enter a sequence(The sequence should not be empty) of integers separated with space: ");
            input = Console.ReadLine();
        } while (input.Length < 1);

        string[] inputNum = input.Split(' ');
        int[] numbers = new int[inputNum.Length];
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNum[i]);
            sum += numbers[i];
        }

        decimal average = (decimal)sum / numbers.Length;
        Console.Clear();
        Console.Write(string.Join(", ", numbers));
        Console.Write("-> average is -> {0}", average);
        Console.WriteLine();


    }

    static void LinearEquation()
    {
        Console.Clear();
        Console.WriteLine("Enter 'a'(a should not be equal to 0) and 'b' in linear equation a*x + b = 0: ");

        decimal a = 0;
        decimal b = 0;

        do
        {
            Console.Write("a = ");
        } while (!(decimal.TryParse(Console.ReadLine(), out a) && a != 0));

        do
        {
            Console.Write("b = ");
        } while (!decimal.TryParse(Console.ReadLine(), out b));

        decimal x = (-b)/a;
        Console.Clear();
        if (b == 0)
        {
            Console.Write("{0}*X = 0 -> x = {1}", a, x);
        }
        else
        {
            Console.Write("{0}*X + {1} = 0 -> x = {2}", a, b, x);
        }
        
        Console.WriteLine();
    }
}

