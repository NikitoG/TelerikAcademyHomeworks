//Problem 8. Prime Number Check

//Write an expression that checks if given positive integer number n (n <= 100) is prime (i.e. it is divisible without remainder only to itself and 1).
//Note: You should check if the number is positive

using System;

class CheksPrimeNumber
{
    static void Main()
    {
    Start:
        uint positiveInt;
        do
        {
            Console.WriteLine("Enter a positiveInt :");
        } while (!(uint.TryParse(Console.ReadLine(), out positiveInt)));

        bool checkIsPrime = false;
        if(positiveInt == 2)
        {
            Console.WriteLine("{0} is prime number! -> {1}", positiveInt, !checkIsPrime);
        }
        else if(positiveInt < 2 || positiveInt % 2 == 0)
        {
            Console.WriteLine("{0} is prime number! -> {1}", positiveInt, checkIsPrime);
        }
        else
        {
            int divider = (int)Math.Sqrt(positiveInt);
            int i;
            for (i = 3; i <= divider+1; i++)
            {
                if (checkIsPrime = (positiveInt % i == 0))
                {
                    break;
                    
                }
               goto final;
            }
            
        final:
            Console.WriteLine("{0} is prime number! -> {1}", positiveInt, !checkIsPrime);

        }

    }
}
