//Problem 6. First larger than neighbours

//Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, 
//if there’s no such element.
//Use the method from the previous exercise.

using System;

class FirstLarger
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
        int index = FindFirstLargerElement(numbers);

        if (index == -1)
        {
            Console.WriteLine("In given array don't have element that is larger than its neighbours!!!");
        }
        else
        {
            Console.WriteLine("First element in array that is larger than its neighbours is on position {0}!", index);
        }
    }
    static int FindFirstLargerElement(int[] numbers)
    {
        int index = -1;
        bool isLarger = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            isLarger = CheckIsLarger(numbers, i);
            if (isLarger == true)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    static bool CheckIsLarger(int[] numbers, int position)
    {
        
            if (numbers.Length == 1)
            {
                return true;
            }
            else if (position == 0)
            {
                if (numbers[position] < numbers[position + 1])
                {
                    return false;
                }
            }
            else if (position == (numbers.Length - 1))
            {
                if (numbers[position] < numbers[position - 1])
                {
                    return false;
                }
            }
            else
            {
                if (numbers[position] < numbers[position + 1])
                {
                    return false;
                }
                if (numbers[position] < numbers[position - 1])
                {
                    return false;
                }

            }
            return true;
    }
}

