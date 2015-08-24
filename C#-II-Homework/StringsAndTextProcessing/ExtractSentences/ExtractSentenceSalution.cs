//Problem 8. Extract sentences

//Write a program that extracts from a given text all sentences containing given word.
//Example:

//The word is: in

//The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.

//Consider that the sentences are separated by . and the words – by non-letter symbols.

using System;
using System.Text.RegularExpressions;

class ExtractSentenceSalution
{
    static void Main()
    {
        //string inputText = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        //string word = "in";
        Console.WriteLine("Enter a text: ");
        string inputText = Console.ReadLine();
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();
        bool isHaveWord = true;
        string[] sentence = inputText.Split('.');
        foreach (var sen in sentence)
        {
            string[] wordsInSentence = Regex.Split(sen, @"\W+");
            for (int i = 0; i < wordsInSentence.Length; i++)
            {

                if (wordsInSentence[i].ToLower() == word.ToLower())
                {
                    Console.Write(sen + ".");
                    isHaveWord = false;
                }
            }
        }
        if (isHaveWord)
        {
            Console.WriteLine("The word is not found in any sentence! ");
        }
        Console.WriteLine();
    }
}
