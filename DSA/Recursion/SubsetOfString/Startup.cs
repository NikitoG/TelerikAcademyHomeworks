namespace SubsetOfString
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var k = 2;
            var set = new string[] { "test", "rock", "fun" };
            var result = new string[k];

            StringSubset(result, set, 0, set.Length, 0);
        }

        private static void StringSubset(string[] result , string[] set, int start, int end, int currentIndex)
        {
            if (currentIndex == result.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", result));
                return;
            }

            for (int i = start; i < end; i++)
            {
                result[currentIndex] = set[i];
                StringSubset(result, set, i + 1, end, currentIndex + 1);
            }
        }
    }
}
