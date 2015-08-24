//Problem 2. Float or Double?

//Which of the following values can be assigned to a variable of type float and which to a variable of type double: 
//34.567839023, 12.345, 8923.1234857, 3456.091?
//Write a program to assign the numbers in variables and print them to ensure no precision is lost.

using System;

class FloatAndDouble
{
    static void Main()
    {
        double firstVar = 34.567839023;
        float secondVar = 12.345f;
        double thirdVar = 8923.1234857;
        float fourthVar = 3456.091f;

        Console.WriteLine("Variable of type double are: {0} and {1}",firstVar,thirdVar);
        Console.WriteLine("Variable of type float are: {0} and {1}", secondVar, fourthVar);

    }
}