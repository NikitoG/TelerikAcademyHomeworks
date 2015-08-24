//Problem 9. Play with Int, Double and String

//Write a program that, depending on the user’s choice, inputs an int, double or string variable.
//If the variable is int or double, the program increases it by one.
//If the variable is a string, the program appends * at the end.
//Print the result at the console. Use switch statement.

using System;

class PlayWithVariables
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("For int press -> 1");
        Console.WriteLine("For double press -> 2");
        Console.WriteLine("For string press -> 3");

        byte chooseType;
        do
        {
            Console.Write("Press 1 or 2 or 3: ");
        } while (!(byte.TryParse(Console.ReadLine(), out chooseType)));

        switch (chooseType)
        {
            case 1:
                int a;
                do
                {
                    Console.Write("Please enter a ineger: ");
                } while (!int.TryParse(Console.ReadLine(), out a));
                Console.WriteLine("input {0} -> return {1}", a, a+1);
                break;

            case 2:
                double b;
                do
                {
                    Console.Write("Please enter a double: ");
                } while (!double.TryParse(Console.ReadLine(), out b));
                Console.WriteLine("input {0} -> return {1}", b, b + 1);
                break;

            case 3:
                Console.Write("Please enter a string: ");
                string strInput = Console.ReadLine();
                Console.WriteLine("input {0} -> return {1}", strInput, strInput + "*");
                break;
            default:
                Console.WriteLine("Wrong input!");
                break;
        }
    }
}
