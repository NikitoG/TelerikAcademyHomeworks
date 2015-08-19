//Problem 4. Appearance count

//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.

using System;
class AppearanceCount
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
        int num;
        do
        {
            Console.Write("Enter a number: ");
        } while (!(int.TryParse(Console.ReadLine(), out num)));

        int count = AppearanceInArray(numbers, num);
        string array = string.Join(", ", numbers);
        Console.WriteLine("How many times {0} appears in {1}? -> {2} times", num, array, count);
    }

    static int AppearanceInArray(int[] numbers, int num)
    {
        int count = 0;
        foreach (int number in numbers)
        {
            if (num == number)
            {
                ++count;
            }
        }
        return count;
    }
}

