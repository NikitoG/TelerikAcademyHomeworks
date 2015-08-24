//Problem 10. Odd and Even Product

//You are given n integers (given in a single line, separated by a space).
//Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
//Elements are counted from 1 to n, so the first element is odd, the second is even, etc.

using System;

class OddEvenProduct
{
    static void Main()
    {
        Console.Write("Enter a n numbers in a single line, separated by a space: ");
        string[] sequanceNum = Console.ReadLine().Split(' ');

        long oddProduct = 1;
        long evenProduct = 1;
        for (int i = 0; i < sequanceNum.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddProduct *= Convert.ToInt64(sequanceNum[i]);
            }
            else
            {
                evenProduct *= Convert.ToInt64(sequanceNum[i]);
            }
        }
        if (oddProduct == evenProduct)
        {
            Console.WriteLine("Product = {0} -> YES", oddProduct);
        }
        else
        {
            Console.WriteLine("Odd product = {0}; Even product = {1} -> NO", oddProduct, evenProduct);
        }


    }
}
