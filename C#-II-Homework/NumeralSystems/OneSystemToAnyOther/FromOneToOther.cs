//Problem 7. One system to any other

//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).

using System;
using System.Collections.Generic;


namespace OneSystemToAnyOther
{
    class FromOneToOther
    {
        static void Main()
        {
            int s = Validation();
            int d = Validation();

            Console.Write("Enter a number to convert: ");
            string input = Console.ReadLine();
            if (InputValidation(input, s))
            {
                double decNum = ToDecimal(input, s);
                Console.Clear();
                Console.WriteLine("{0} -> {1}", input, FromDecimalToAnyOther(decNum, d));
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }



        }

        static bool InputValidation(string input, int numeral)
        {
            char[] hexadecimal = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            bool validation = false;
            foreach (char ch in input)
            {
                validation = false;
                for (int i = 0; i < numeral; i++)
                {
                    if (ch.CompareTo(hexadecimal[i]) == 0)
                    {
                        validation = true;
                        break;
                    }
                }
                if (!validation)
                {
                    break;
                }
            }
            return validation;
        }

        static int Validation()
        {
            int num;
            do
            {
                Console.Write("Enter number in a range[2...16]: ");
            } while (!(int.TryParse(Console.ReadLine(), out num) && num >= 2 && num <= 16));
            return num;
        }
        static double ToDecimal(string input, int numeral)
        {
            double decimalNum = 0;
            double power = input.Length - 1;
            foreach (char num in input)
            {
                if (char.IsDigit(num))
                {
                    decimalNum += (num - '0') * Math.Pow(numeral, power);
                    --power;
                }
                else if (char.IsUpper(num) && num.CompareTo('A') >= 0 && num.CompareTo('F') <= 0)
                {
                    decimalNum += (num - '7') * Math.Pow(numeral, power);
                    --power;
                }

            }

            return decimalNum;
        }

        static string FromDecimalToAnyOther(double number, int numeral)
        {
            int temp = (int)number;
            int index = 0;
            char[] hexadecimal = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            List<char> hexadecimalNum = new List<char>();
            while (temp != 0)
            {
                index = temp % numeral;
                hexadecimalNum.Add(hexadecimal[index]);
                temp /= numeral;
            }
            hexadecimalNum.Reverse();

            return string.Join("", hexadecimalNum);
        }
    }
}
