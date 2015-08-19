//Problem 4. Hexadecimal to decimal

//Write a program to convert hexadecimal numbers to their decimal representation.

using System;


namespace HexadecimalToDecimal
{
    class HexToDec
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a hexadecimal number: ");
            string hexadecimalNum = Console.ReadLine();

            double decimalNum = 0;
            double power = hexadecimalNum.Length - 1;
            bool wrongInput = true;
            foreach (char num in hexadecimalNum)
            {
                if (char.IsDigit(num))
                {
                    decimalNum += (num - '0') * Math.Pow(16, power);
                    --power;
                }
                else if (char.IsUpper(num) && num.CompareTo('A') >= 0 && num.CompareTo('F') <= 0)
                {
                    decimalNum += (num - '7') * Math.Pow(16, power);
                    --power;
                }
                else
                {
                    wrongInput = false;
                }

            }

            Console.Clear();
            if (wrongInput)
            {
                Console.WriteLine("{0} in decimal {1}", hexadecimalNum, decimalNum);
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
            
        }
    }
}
