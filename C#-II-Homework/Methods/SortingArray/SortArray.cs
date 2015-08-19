//Problem 9. Sorting array

//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

using System;

class SortArray
{
    static void Main()
    {
        Console.Write("Enter integers separated by a space: ");
        string[] inputNum = Console.ReadLine().Split(' ');
        int[] numbers = new int[inputNum.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNum[i]);
        }
        int position;
        do
        {
            Console.Write("Enter a index between 0 and {0}: ", numbers.Length - 1);
        } while (!(int.TryParse(Console.ReadLine(), out position)));

        int index = 0;
        if (position >= numbers.Length || position < 0)
        {
            Console.WriteLine("Wrong input!!!");
        }
        else
        {
            index = MaximalElement(numbers, position);
            Console.WriteLine("The maximal element in a portion of array of integers starting at index {0} is {1}!", position, numbers[index]);
        }

        bool ascending = true;
        int[] sortsArrayDescending = SortsArray(numbers);
        Console.WriteLine(string.Join(", ", sortsArrayDescending));

        int[] sortsArrayAscending = SortsArray(numbers, ascending);
        Console.WriteLine(string.Join(", ", sortsArrayAscending));
    }

    static int MaximalElement(int[] numbers, int position, bool ascending = false)
    {
        int maxElement = int.MinValue;
        int minElement = int.MaxValue;
        int index = 0;
        for (int i = position; i < numbers.Length; i++)
        {
            if (ascending)
            {
                if (numbers[i] < minElement)
                {
                    minElement = numbers[i];
                    index = i;
                }
            }
            else
            {
                if (numbers[i] > maxElement)
                {
                    maxElement = numbers[i];
                    index = i;
                }
            }

        }

        return index;
    }

    static int[] SortsArray(int[] numbers, bool ascending = false)
    {
        int index = 0;
        int temp = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            index = MaximalElement(numbers, i, ascending);
            temp = numbers[i];
            numbers[i] = numbers[index];
            numbers[index] = temp;

        }

        return numbers;
    }
}

