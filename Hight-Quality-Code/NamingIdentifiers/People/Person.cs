namespace People
{
    using System;

    public class Person
    {
        public Person(int age)
        {
            this.Age = age;
            if (age % 2 == 0)
            {
                this.Name = "Niki";
                this.Gender = Gender.Male;
            }
            else
            {
                this.Name = "Ani";
                this.Gender = Gender.Female;
            }
        }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}; Gender: {1}; Age: {2}!", this.Name, this.Gender, this.Age);
        }
    }
}
