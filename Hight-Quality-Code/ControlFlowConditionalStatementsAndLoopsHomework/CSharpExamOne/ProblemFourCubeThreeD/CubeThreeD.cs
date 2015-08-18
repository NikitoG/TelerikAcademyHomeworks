using System;

public class CubeThreeD
{
    public static void Main()
    {
        int numbersOfLines = int.Parse(Console.ReadLine());
        //// ::::::
        Console.WriteLine(new string(':', numbersOfLines));
        //// :    ::    
        Console.Write(':');
        Console.Write(new string(' ', numbersOfLines - 2));
        Console.WriteLine("::");
        //// :    :|:   
        //// :    :||:  
        //// :    :|||: 
        for (int i = 1; i <= numbersOfLines - 3; i++)
        {
            Console.Write(':');
            Console.Write(new string(' ', numbersOfLines - 2));
            Console.Write(":");

            Console.Write(new string('|', i));
            Console.WriteLine(':');
        }

        //// ::::::||||:
        Console.Write(new string(':', numbersOfLines));
        Console.Write(new string('|', numbersOfLines - 2));
        Console.WriteLine(':');

        //// :----:|||:
        ////  :----:||:
        ////   :----:|:
        int count = numbersOfLines - 3;
        for (int i = 1; i <= numbersOfLines - 3; i++)
        {
            Console.Write(new string(' ', i));
            Console.Write(':');
            Console.Write(new string('-', numbersOfLines - 2));
            Console.Write(':');
            Console.Write(new string('|', count));
            Console.WriteLine(':');
            --count;
        }
        ////    :----::
        Console.Write(new string(' ', numbersOfLines - 2));
        Console.Write(':');
        Console.Write(new string('-', numbersOfLines - 2));
        Console.WriteLine("::");
        ////     ::::::
        Console.Write(new string(' ', numbersOfLines - 1));
        Console.WriteLine(new string(':', numbersOfLines));
    }
}