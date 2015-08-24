//Problem 5. Hexadecimal to binary

//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexadecimalToBinary
{
    class HexToBin
    {
        static void Main()
        {
            Console.Write("Enter a hexadecimal number: ");
            string hexadecimalNum = Console.ReadLine();

            string[] hexToDec = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", 
                                    "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            int index = 0;
            List<string> binaryNum = new List<string>();
            bool wrongInput = true;
            foreach (char digit in hexadecimalNum)
            {
                if (char.IsDigit(digit))
                {
                    index = digit - '0';
                    binaryNum.Add(hexToDec[index]);
                }
                else if (char.IsUpper(digit) && digit.CompareTo('A') >= 0 && digit.CompareTo('F') <= 0)
                {
                    index = digit - '7';
                    binaryNum.Add(hexToDec[index]);
                }
                else
                {
                    wrongInput = false;
                    break;
                }
            }

            Console.Clear();
            if (wrongInput)
            {
                Console.WriteLine("{0} in binary {1}", hexadecimalNum, string.Join("",binaryNum));
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
            
        }
    }
}
