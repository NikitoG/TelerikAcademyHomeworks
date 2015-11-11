namespace CombinationWithoutRepetition
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());
            var result = new int[k];

            CombinationWithOutDuplicates(result, 1, n, 0);
        }

        private static void CombinationWithOutDuplicates(int[] result, int start, int end, int currentIndex)
        {
            if (currentIndex == result.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", result));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                result[currentIndex] = i;
                CombinationWithOutDuplicates(result, i + 1, end, currentIndex + 1);
            }
        }
    }
}
