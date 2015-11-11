namespace StudentsCourses
{
    using System;

    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public override string ToString()
        {
            return this.FullName;
        }

        public int CompareTo(Student other)
        {
            var result = this.LastName.CompareTo(other.LastName);

            if (result == 0)
            {
                result = this.FirstName.CompareTo(other.FirstName);
            }

            return result;
        }
    }
}
