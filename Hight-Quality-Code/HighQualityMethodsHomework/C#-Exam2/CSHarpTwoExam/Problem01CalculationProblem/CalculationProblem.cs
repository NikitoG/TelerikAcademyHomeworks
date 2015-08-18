namespace Problem01CalculationProblem
{
    using System;
    using System.Numerics;
    using System.Text;

    /// <summary>
    /// Sum all of the letter-numbers and print out the resulting sum both in the 23-based system and decimal system 
    /// </summary>
    internal class CalculationProblem
    {
        /// <summary>
        /// Print result
        /// </summary>
        private static void Main()
        {
            string[] inputText = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            BigInteger sum = CalculateSum(inputText);

            string sumIn13th = GetNumberIn23th(sum);

            Console.WriteLine("{0} = {1}", sumIn13th, sum);
        }

        /// <summary>
        /// Calculate sum.
        /// </summary>
        /// <param name="inputText">String array - number in 23-based system.</param>
        /// <returns>Big integer - sum in decimal system.</returns>
        private static BigInteger CalculateSum(string[] inputText)
        {
            BigInteger currentNumber = 0;
            BigInteger sum = 0;
            foreach (var num in inputText)
            {
                currentNumber = GetNumberIn10th(num);
                sum += currentNumber;
            }

            return sum;
        }

        /// <summary>
        /// Convert number from decimal system to the 23-based system.
        /// </summary>
        /// <param name="sum">Big integer - in decimal system</param>
        /// <returns>String - number in 23-based system.</returns>
        private static string GetNumberIn23th(BigInteger sum)
        {
            char[] digits = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w' };
            StringBuilder num = new StringBuilder();
            char digit;
            int index = 0;
            while (sum != 0)
            {
                index = (int)sum % 23;
                sum /= 23;
                digit = digits[index];
                num.Insert(0, digit);
            }

            return num.ToString();
        }

        /// <summary>
        /// Convert number from 2-based to decimal system.
        /// </summary>
        /// <param name="num">String - number in 23-based system.</param>
        /// <returns>Big integer - number in decimal system.</returns>
        private static BigInteger GetNumberIn10th(string num)
        {
            int power = num.Length - 1;
            BigInteger result = 0;
            foreach (var digit in num)
            {
                result += (digit - 'a') * PowerOf23(power);
                --power;
            }

            return result;
        }

        /// <summary>
        /// Calculate power of 23
        /// </summary>
        /// <param name="power">Integer - power</param>
        /// <returns>Big integer - power of 23</returns>
        private static BigInteger PowerOf23(int power)
        {
            BigInteger pow = 1;
            if (power == 0)
            {
                pow = 1;
            }
            else
            {
                for (int i = 0; i < power; i++)
                {
                    pow *= 23;
                }
            }

            return pow;
        }
    }
}
