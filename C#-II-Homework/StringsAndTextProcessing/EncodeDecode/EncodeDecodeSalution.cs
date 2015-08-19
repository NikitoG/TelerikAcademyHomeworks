//Problem 7. Encode/decode

//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters.
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first 
//letter of the string with the first of the key, the second – with the second, etc. When 
//the last key character is reached, the next is the first.

using System;

class EncodeDecodeSalution
{
    static void Main(string[] args)
    {
        Console.Write("Enter a sentence for coded: ");
        string inputStr = Console.ReadLine();
        Console.Write("Enter a encryption key: ");
        string codeKey = Console.ReadLine();
        int[] coded = new int[inputStr.Length];
        string decoded = string.Empty;
        for (int i = 0; i < inputStr.Length; i++)
        {
            coded[i]= inputStr[i] ^ codeKey[i % codeKey.Length];

        }
        Console.Write("Coded: ");
        foreach (int ch in coded)
        {
            Console.Write("\\u{0:x4}", ch);
        }
        Console.WriteLine();
        for (int i = 0; i < coded.Length; i++)
        {
            decoded += (char)(coded[i] ^ codeKey[i % codeKey.Length]);
        }
        Console.Write("Decoded: {0}", decoded);
        Console.WriteLine();

    }
}
