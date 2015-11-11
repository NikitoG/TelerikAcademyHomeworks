namespace Permutation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            var result = new int[n];
            for (int i = 1; i <= n; i++)
            {
                result[i - 1] = i;
            }

            GetPermutation(result, 0);
        }

        private static void GetPermutation(int[] result, int currentIndex)
        {
            if (currentIndex >= result.Length)
            {
                Console.WriteLine("{{{0}}} ", string.Join(", ", result));
                return;
            }

            GetPermutation(result, currentIndex + 1);
            for (int i = currentIndex + 1; i < result.Length; i++)
            {
                Swap(result, currentIndex, i);

                GetPermutation(result, currentIndex + 1);

                Swap(result, currentIndex, i);
            }
        }

        private static void Swap(int[] result, int firstIndex, int secondIndex)
        {
            var oldValue = result[firstIndex];
            result[firstIndex] = result[secondIndex];
            result[secondIndex] = oldValue;
        }
    }
}
