//Problem 5. Sort by string length

//You are given an array of strings. Write a method that sorts the array by the length of its elements 
//(the number of characters composing them).

using System;

class StringLenght
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("N = ");
        } while (!(int.TryParse(Console.ReadLine(), out N) && N > 0));

        string[] inputString = new string[N];
        for (int i = 0; i < inputString.Length; i++)
        {
            Console.Write("inputString[{0}] = ", i);
            inputString[i] = Console.ReadLine();
        }

        Console.Write("Unsorted array: ");
        Console.WriteLine(string.Join(", ", inputString));

        // use .NET functionality(ascending):
        Array.Sort(inputString, (x,y)=>x.Length.CompareTo(y.Length));
        Console.Write("Sorted array: ");
        Console.WriteLine(string.Join(", ", inputString));

        //second way(descending);
        for (int i = 0; i < inputString.Length - 1; i++)
        {
            for (int j = i + 1; j < inputString.Length; j++)
            {
                if (inputString[i].Length < inputString[j].Length)
                {
                    string temp = inputString[j];
                    inputString[j] = inputString[i];
                    inputString[i] = temp;

                }
            }
        }
        Console.Write("Sorted array: ");
        Console.WriteLine(string.Join(", ", inputString));
    }
}

