namespace InheritanceAndPolymorphism
{
    using System;

    internal class Validator
    {
        public static void ValidateName(string value, string name = null)
        {
            if (name == null)
            {
                name = "Value";
            }

            if (value.Length < 3)
            {
                throw new ArgumentOutOfRangeException(name + " must have a least three characters!");
            }
        }

        public static void IsNull(string value, string name)
        {
            if (name == null)
            {
                name = "Value";
            }

            if (value == null)
            {
                throw new NullReferenceException(name + "can not be null!");
            }
        }
    }
}
