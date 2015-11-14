namespace ColoredRabbits
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfRabbits = int.Parse(Console.ReadLine());
            var answers = new Dictionary<int, int>();
            for (int i = 0; i < numberOfRabbits; i++)
            {
                var answer = int.Parse(Console.ReadLine());
                if (!answers.ContainsKey(answer))
                {
                    answers[answer] = 0;
                }

                answers[answer]++;
            }

            var allrabits = 0;

            foreach (var sameRabbits in answers)
            {
                if(sameRabbits.Key >= sameRabbits.Value)
                {
                    allrabits += sameRabbits.Key + 1;
                }
                else
                {
                    var rabbitsWithSameColor = sameRabbits.Key + 1;
                    allrabits += (int)Math.Ceiling((double)sameRabbits.Value / (double)rabbitsWithSameColor) * rabbitsWithSameColor;
                }
            }

            Console.WriteLine(allrabits);
        }
    }
}
