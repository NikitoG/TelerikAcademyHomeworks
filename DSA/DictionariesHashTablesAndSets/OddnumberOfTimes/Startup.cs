namespace OddnumberOfTimes
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var sequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var stringCount = new Dictionary<string, int>();

            foreach (var str in sequence)
            {
                if (!stringCount.ContainsKey(str))
                {
                    stringCount.Add(str, 0);
                }

                stringCount[str]++;
            }

            foreach (var pair in stringCount)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
            }
        }
    }
}
