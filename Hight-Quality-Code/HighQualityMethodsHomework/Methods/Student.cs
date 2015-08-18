namespace Methods
{
    using System;

    /// <summary>
    /// Class for student.
    /// </summary>
    internal class Student
    {
        private string firstName;
        private string lastName;
        private DateTime birthDay;
        private string town;

        /// <summary>
        /// Constructor for the class student
        /// </summary>
        /// <param name="firstName">String - student`s first name.</param>
        /// <param name="lastName">String - student`s last name.</param>
        /// <param name="birthDay">DateTime - student`s date of birth.</param>
        /// <param name="town">String - students`s town.</param>
        /// <param name="otherInfo">String - other information.</param>
        public Student(string firstName, string lastName, DateTime birthDay, string town, string otherInfo = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.Town = town;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("First name bust larger than 2 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Last name bust larger than 2 symbols!");
                }

                this.lastName = value;
            }
        }

        public DateTime BirthDay
        {
            get
            {
                return this.birthDay;
            }

            set
            {
                if (value.Year < 1900)
                {
                    throw new ArgumentOutOfRangeException("Year of birth must be greater than 1900!");
                }

                this.birthDay = value;
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The name of a town must be larger than 2 symbols!");
                }

                this.town = value;
            }
        }

        public string OtherInfo { get; set; }

        /// <summary>
        /// The methods compare the birth date of given student to another.
        /// </summary>
        /// <param name="other">Student - other student.</param>
        /// <returns>True - if the student is older then the other.</returns>
        public bool IsOlderThan(Student other)
        {
            return this.BirthDay < other.BirthDay;
        }
    }
}