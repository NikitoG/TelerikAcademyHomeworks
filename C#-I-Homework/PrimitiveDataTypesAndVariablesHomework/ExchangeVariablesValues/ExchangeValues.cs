﻿//Problem 9. Exchange Variable Values

//Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
//Print the variable values before and after the exchange.

using System;

class ExchangeValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("a={0}\tb={1}", a, b);

        int c = a;
        a = b;
        b = c;
        Console.WriteLine("a={0}\tb={1}\tfirst exchange.", a, b);

        a ^= b;
        b ^= a;
        a ^= b;
        Console.WriteLine("a={0}\tb={1}\tsecond exchange.", a, b);

        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("a={0}\tb={1}\tthird exchange.", a, b);


    }
}
