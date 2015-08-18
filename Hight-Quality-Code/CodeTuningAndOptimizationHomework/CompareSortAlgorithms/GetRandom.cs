namespace CompareSortAlgorithms
{
    using System;

    internal class GetRandom
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random Getrandom = new Random();

        public static int IntegerNumber(int min, int max)
        {
            return Getrandom.Next(min, max);
        }

        public static double DoubleNumber(double minimum, double maximum)
        {
            return (Getrandom.NextDouble() * (maximum - minimum)) + minimum;
        }

        public static string CharSequence(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = Chars[Getrandom.Next(Chars.Length)];
            }

            return new string(buffer);
        }
    }
}
