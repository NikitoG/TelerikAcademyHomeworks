namespace CohesionAndCoupling
{
    using System;

    internal class Validator
    {
        public static void ValidateSize(double size, string name = null)
        {
            if (name == null)
            {
                name = "Value";
            }

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(name + " must be greater than zero!");
            }
        }
    }
}
