//Problem 2. Get largest number

//Write a method GetMax() with two parameters that returns the larger of two integers.
//Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

using System;

class ReturnMaxNumber
{
    static int ValidationOfInt(string num)
    {
        int integer = 0;
        do
        {
            Console.Write("Enter a {0} integer: ", num);
        } while (!int.TryParse(Console.ReadLine(), out integer));
        return integer;
    }
    static void Main()
    {
        int firstNum = ValidationOfInt("first");
        int secondNum = ValidationOfInt("second");
        int thirdNum = ValidationOfInt("third");

        int largestNum = GetMax(GetMax(firstNum,secondNum), thirdNum);
        Console.Clear();
        Console.WriteLine("The largest of {0}, {1} and {2} is {3}!", firstNum, secondNum, thirdNum, largestNum);

    }

    static int GetMax(int firstNum, int secondNum)
    {
        if (firstNum > secondNum)
        {
            return firstNum;
        }
        return secondNum;
    }
}