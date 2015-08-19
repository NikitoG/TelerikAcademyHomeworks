//Problem 5. Larger than neighbours

//Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).

using System;

class CompareNeighbours
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
        if (position < 0 || position >= numbers.Length)
        {
            Console.WriteLine("Wrong input, index out of range!");
        }
        else
        {
            bool isLarger = CheckIsLarger(numbers, position);

            Console.WriteLine("The element at position {0} is larger than its neighbours! - {1}", position, isLarger);
        }


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

