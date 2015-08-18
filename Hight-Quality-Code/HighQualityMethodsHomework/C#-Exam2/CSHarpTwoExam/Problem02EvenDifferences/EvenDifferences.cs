namespace Problem02EvenDifferences
{
    using System;

    /// <summary>
    /// Calculate even difference.
    /// </summary>
    public class EvenDifferences
    {
        /// <summary>
        /// Play the game.
        /// </summary>
        public static void Main()
        {
            string[] numbersInstring = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long[] numbers = new long[numbersInstring.Length];
            for (int i = 0; i < numbersInstring.Length; i++)
            {
                numbers[i] = long.Parse(numbersInstring[i]);
            }

            ulong sumEvenDeff = CalculateSumOfEvenDefference(numbers);
            Console.WriteLine(sumEvenDeff);
        }

        /// <summary>
        /// Calculate sum of the even difference.
        /// </summary>
        /// <param name="numbers">Array - sequence of numbers.</param>
        /// <returns>Unsigned 64-bit integer - sum of the even difference.</returns>
        public static ulong CalculateSumOfEvenDefference(long[] numbers)
        {
            int index = 1;
            long jump = 0;
            int steps = 0;
            ulong sumEvenDeff = 0;
            while (true)
            {
                if (numbers[index] >= numbers[index - 1])
                {
                    jump = numbers[index] - numbers[index - 1];
                }
                else
                {
                    jump = numbers[index - 1] - numbers[index];
                }

                if (jump % 2 == 0)
                {
                    steps = 2;
                    sumEvenDeff += (ulong)jump;
                }
                else
                {
                    steps = 1;
                }

                index += steps;
                if (index >= numbers.Length)
                {
                    break;
                }
            }

            return sumEvenDeff;
        }
    }
}
