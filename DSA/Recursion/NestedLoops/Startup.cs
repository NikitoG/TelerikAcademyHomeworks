namespace NestedLoops
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Enter n for neted loops: ");
            int numberOfLoops = int.Parse(Console.ReadLine());
            var result = new int[numberOfLoops];
            Loops(result, numberOfLoops, 0);
        }

        private static void Loops(int[] result, int numberOfLoops, int currentIndex)
        {
            if (currentIndex == numberOfLoops)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = 1; i <= numberOfLoops; i++)
            {
                result[currentIndex] = i;
                currentIndex++;
                Loops(result, numberOfLoops, currentIndex);
                currentIndex--;
            }
        }
    }
}
