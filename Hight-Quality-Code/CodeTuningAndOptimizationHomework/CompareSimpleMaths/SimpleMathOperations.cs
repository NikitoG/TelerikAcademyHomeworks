namespace CompareSimpleMaths
{
    using System;

    internal class SimpleMathOperations
    {
        private const int NumberOfIteration = 5000000;

        internal static void Add(dynamic number)
        {
            for (int i = 0; i < NumberOfIteration; i++)
            {
                number += 1;
            }
        }

        internal static void Substract(dynamic number)
        {
            for (int i = 0; i < NumberOfIteration; i++)
            {
                number -= 1;
            }
        }

        internal static void Increment(dynamic number)
        {
            for (int i = 0; i < NumberOfIteration; i++)
            {
                number++;
            }
        }

        internal static void Multiply(dynamic number)
        {
            for (int i = 0; i < NumberOfIteration; i++)
            {
                number *= 1;
            }
        }

        internal static void Divide(dynamic number)
        {
            for (int i = 0; i < NumberOfIteration; i++)
            {
                number /= 1;
            }
        }
    }
}
