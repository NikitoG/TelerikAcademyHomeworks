//Problem 16. Decimal to Hexadecimal Number

//Using loops write a program that converts an integer number to its hexadecimal representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

using System;

class DecToHex
{
    static void Main()
    {
        checked
        {

            long decNum;
            do
            {
                Console.WriteLine("Write a integer number: ");
            } while (!long.TryParse(Console.ReadLine(), out decNum));

            long number = Math.Abs(decNum);
            string hexNum = "";
            long reminder;
            char index = ' ';

            do
            {
                reminder = number % 16;
                switch (reminder)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        index = (char)(reminder + 48);
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        index = (char)(reminder + 55);
                        break;
                }
                hexNum = Convert.ToString(index) + hexNum;
                number /= 16;
            } while (number != 0);
            Console.WriteLine(hexNum);
        }
    }
}
