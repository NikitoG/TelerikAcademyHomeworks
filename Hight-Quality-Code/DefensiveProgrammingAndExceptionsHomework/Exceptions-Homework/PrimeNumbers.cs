namespace Exceptions_Homework
{
    using System;

    public class PrimeNumbers
    {
        public static bool Check(int number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Numer cannot be null!");
            }

            if (number <= 1)
            {
                return false;
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
