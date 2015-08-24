//Problem 6. binary to hexadecimal

//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Collections.Generic;

namespace BinaryToHexadecimal
{
    class BinToHex
    {
        static void Main()
        {
            Console.Write("Enter a binary number: ");
            string binaryNum = Console.ReadLine();

            if (binaryNum.Length % 4 != 0)
            {
                int length = binaryNum.Length % 4;
                for (int i = 0; i < (4 - length); i++)
                {
                    binaryNum = binaryNum.Insert(0, "0");
                }
            }

            List<string> hexadecimalNum = new List<string>();
            bool wrongInput = true;
            for (int i = 0; i < binaryNum.Length; i += 4)
            {
                switch (binaryNum.Substring(i, 4))
                {
                    case "0000": hexadecimalNum.Add("0"); break;
                    case "0001": hexadecimalNum.Add("1"); break;
                    case "0010": hexadecimalNum.Add("2"); break;
                    case "0011": hexadecimalNum.Add("3"); break;
                    case "0100": hexadecimalNum.Add("4"); break;
                    case "0101": hexadecimalNum.Add("5"); break;
                    case "0110": hexadecimalNum.Add("6"); break;
                    case "0111": hexadecimalNum.Add("7"); break;
                    case "1000": hexadecimalNum.Add("8"); break;
                    case "1001": hexadecimalNum.Add("9"); break;
                    case "1010": hexadecimalNum.Add("A"); break;
                    case "1011": hexadecimalNum.Add("B"); break;
                    case "1100": hexadecimalNum.Add("C"); break;
                    case "1101": hexadecimalNum.Add("D"); break;
                    case "1110": hexadecimalNum.Add("E"); break;
                    case "1111": hexadecimalNum.Add("F"); break;
                    default: wrongInput = false; break;
                } 
            }

            Console.Clear();
            if (wrongInput)
            {
                Console.WriteLine("{0} in hexaecimal {1}", binaryNum, string.Join("", hexadecimalNum));
            }
            else
            {
                Console.WriteLine("wrong input!");
            }
        }
    }
}
