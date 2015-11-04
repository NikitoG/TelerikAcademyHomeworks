namespace FindMajorantOfAnArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        //The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

        //Write a program to find the majorant of given array (if exists).

        public static void Main()
        {
            var numbers = new int[9] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            MajorantOfArray(numbers);
        }

        public static void MajorantOfArray(int[] sequence)
        {
            Dictionary<int, int> countNumbers = new Dictionary<int, int>();

            foreach (var number in sequence)
            {
                if (!countNumbers.ContainsKey(number))
                {
                    countNumbers[number] = 0;
                }

                countNumbers[number]++;
            }

            var majorantList = countNumbers
                .Where(n => n.Value == sequence.Length / 2 + 1)
                .Select(n => n.Key)
                .ToList();

            if(majorantList.Count > 0)
            {
                Console.WriteLine("Majorant: {0}", majorantList[0]);
            }
            else
            {
                Console.WriteLine("There is no majorants!");
            }
        }
    }
}
