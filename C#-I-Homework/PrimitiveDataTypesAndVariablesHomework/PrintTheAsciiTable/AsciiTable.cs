//Problem 14.* Print the ASCII Table

//Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).

using System;
using System.Text;

class AsciiTable
{
    static void Main()
    {
        int Number;
        for (Number = 0; Number < 256; Number++)
        {
            Console.OutputEncoding = Encoding.Unicode;
            char symbol = (char)Number;
            Console.WriteLine(Number + " " + symbol);

        }
    }
}