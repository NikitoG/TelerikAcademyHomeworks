namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private const int MinValueUniqueNumber = 10000;
        private const int MaxValueUniqueNumber = 99999;
        private static readonly Random GetRandom = new Random();

        private string name;
        private int uniqueNumber;
        private List<int> listUniqueNumbers = new List<int>();

        public Student(string name)
        {
            this.Name = name;
            this.UniqueNumber = this.GetUniqueNumber();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Name cannot be null or Empty!");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                if (value < MinValueUniqueNumber || value > MaxValueUniqueNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Unique number must be between {0} and {1}", MinValueUniqueNumber, MaxValueUniqueNumber + 1));
                }

                while (this.listUniqueNumbers.Contains(value))
                {
                    value = this.GetUniqueNumber();
                }

                this.uniqueNumber = value;
            }
        }

        private int GetUniqueNumber()
        {
            return GetRandom.Next(MinValueUniqueNumber, MaxValueUniqueNumber);
        }
    }
}
