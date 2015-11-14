namespace BinaryPassword
{
    using System;

    public class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine();

            int n = 0;
            foreach (var symbol in input)
            {
                if(symbol == '*')
                {
                    n++;
                }
            }

            ulong result = 1;
            if (n == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    result *= 2;
                }
                Console.WriteLine(result);
            }
        }
    }
}
