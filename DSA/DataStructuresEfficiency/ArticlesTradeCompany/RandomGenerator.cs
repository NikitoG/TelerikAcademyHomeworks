using System;
using System.Text;
namespace ArticlesTradeCompany
{
    public static class RandomGenerator
    {
        private const string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly Random RandomGen = new Random();

        public static string GetRandomString(int length, bool onlyDigits)
        {
            var allowedChars = Chars.Length;
            if (onlyDigits)
            {
                allowedChars = 10;
            }

            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(Chars[RandomGen.Next(0, allowedChars)]);
            }

            return result.ToString();
        }

        public static decimal GetRandomDecimal()
        {
            var minValue = 0.10;
            var maxValue = 100.0;
            var next = RandomGen.NextDouble();

            return (decimal)Math.Round(minValue + (next * (maxValue - minValue)), 2);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return RandomGen.Next(min, max + 1);
        }
    }
}
