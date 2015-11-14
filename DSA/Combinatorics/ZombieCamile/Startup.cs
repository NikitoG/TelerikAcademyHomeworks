namespace ZombieCamile
{
    using System;

    public class Startup
    {
	    private static int n;
	    private static ulong distance = 0;
        private static ulong result = 0; 

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputAsString = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(inputAsString))
                {
                    var input = inputAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var x = int.Parse(input[0]);
                    if (x < 0)
                    {
                        x *= -1;
                    }
                    var y = int.Parse(input[1]);
                    if (y < 0)
                    {
                        y *= -1;
                    }
                    distance += (ulong)(x + y);
                }
                else
                {
                    i--;
                }
            }

            ulong numberOfCombination = 1ul << (n - 1);
            result = distance * (ulong)numberOfCombination;

            Console.WriteLine(result);
        }
    }
}