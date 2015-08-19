//Problem 2. Compare arrays

//Write a program that reads two integer arrays from the console and compares them element by element.

using System;

class Compare
{
    static void Main()
    {
        Console.Write("Number of element in a first array = ");
        int arrLength1 = int.Parse(Console.ReadLine());
        int arrLength2 = 0;
        int[] firstArray = new int[arrLength1];

        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("firstArray[{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Number of element in a second array = ");
        arrLength2 = int.Parse(Console.ReadLine());
        int[] secondArray = new int[arrLength2];
        for (int i = 0; i < secondArray.Length; i++)
        {
            Console.Write("secondArray[{0}] = ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool isEqual = true;
        if (arrLength1 != arrLength2)
        {
            Console.WriteLine("Two arrays are with different length and they can't be equal.");
        }
        else
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    isEqual = false;
                    break;
                }
            }
            Console.WriteLine("Are equal? -> {0}", isEqual);
        }
    }
}
