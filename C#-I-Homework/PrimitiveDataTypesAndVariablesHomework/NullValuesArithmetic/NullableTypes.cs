//Problem 12. Null Values Arithmetic

//Create a program that assigns null values to an integer and to a double variable.
//Try to print these variables at the console.
//Try to add some number or the null literal to these variables and print the result.

using System;

class NullableTypes
{
    static void Main()
    {
        int? nullInteger = null;
        double? nullDouble = null;
        Console.WriteLine("Integer with Null value ->" + nullInteger);
        Console.WriteLine("Real number with Null value ->" + nullDouble);

        nullInteger = 8;
        nullDouble = 6.5;
        Console.WriteLine("Integer with value -> " + nullInteger);
        Console.WriteLine("Real number with value -> " + nullDouble);
    }
}
