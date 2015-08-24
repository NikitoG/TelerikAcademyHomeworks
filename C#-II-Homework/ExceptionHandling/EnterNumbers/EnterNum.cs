//Problem 2. Enter numbers

//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class EnterNum
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        int count = 10;

        int[] numbers = new int[count];

        Console.WriteLine("Enter {0} numbers in a range [{1}...{2}]", count, start, end);
        for (int i = 0; i < count; )
        {
            try
            {
                Console.Write("{0} is ", i);
                numbers[i] = ReadNumber(start, end);
                start = numbers[i];
                ++i;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number was out of range!");
            }
            catch (FormatException)
            {

            }

        }
    }

    static int ReadNumber(int start = int.MinValue, int end = int.MaxValue)
    {
        int number = 0;
        try
        {
            number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return number;
        }
        catch (ArgumentNullException)
        {

            Console.WriteLine("Null is not valid input!");
            throw new FormatException();
        }
        catch (FormatException)
        {

            Console.WriteLine("Input should be number!");
            throw new FormatException();
        }
        catch (OverflowException)
        {

            Console.WriteLine("Number is too big or too small!");
            throw new FormatException();
        }
        return number;

    }
}

