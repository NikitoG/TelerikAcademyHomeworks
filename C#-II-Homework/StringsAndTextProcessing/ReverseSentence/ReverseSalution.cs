//Problem 13. Reverse sentence

//Write a program that reverses the words in given sentence.

using System;
using System.Text;
using System.Collections.Generic;
class ReverseSalution
{
    static void Main()
    {
        //Console.WriteLine("Enter a sentence: ");
        //string inputSentence = Console.ReadLine();
        string inputSentence = "C# is not C++, not PHP and not Delphi!";
        List<string> words = new List<string>(inputSentence.Split(' '));
        Dictionary<int, char> punctoation = new Dictionary<int, char>();
        for (int i = 0; i < words.Count; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (words[i][j] == ',' || words[i][j] == '.' || words[i][j] == '!' || words[i][j] == '?')
                {
                    punctoation[i] = words[i][j];
                    words[i] = words[i].Remove(j);
                }
            }
        }
        words.Reverse();
        for (int i = 0; i < words.Count; i++)
        {
            Console.Write(words[i]);
            if (punctoation.ContainsKey(i))
            {
                Console.Write(punctoation[i]);
                if (i != words.Count - 1)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();

    }
}

