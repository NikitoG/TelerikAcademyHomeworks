namespace CombinationWithRepetition
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var n=3;
            var k=2;
            var set = new string[] { "hi", "a", "b" };
            var result = new string[k];

            GetCombination(result, set, 0);
        }

        private static void GetCombination(string[] result, string[] set, int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine("{{{0}}}", string.Join(", ", result));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                result[index] = set[i];
                GetCombination(result, set, index + 1);
            }
        }
    }
}
