//Problem 9. Forbidden words

//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.
//Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.

//Forbidden words: PHP, CLR, Microsoft

//The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Text;
class ForbiddenWordsSalution
{
    static void Main()
    {
        //string inputText = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        //string[] words = { "PHP", "CLR", "Microsoft" };
        Console.WriteLine("Enter a text: ");
        string inputText = Console.ReadLine();
        Console.Write("Enter a wors for raplace separated by a space: ");
        string[] words = Console.ReadLine().Split(' ');

        StringBuilder forbiddenWords = new StringBuilder(inputText);
        for (int i = 0; i < words.Length; i++)
        {
            forbiddenWords = forbiddenWords.Replace(words[i], new string('*', words[i].Length));
        }
        Console.WriteLine(forbiddenWords.ToString());
    }
}

