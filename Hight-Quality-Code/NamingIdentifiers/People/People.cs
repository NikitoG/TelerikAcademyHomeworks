namespace People
{
    using System;

    public class People
    {
        public static void Main()
        {
            Person male = new Person(34);
            Person female = new Person(33);

            Console.WriteLine(male);
            Console.WriteLine(female);
        }
    }
}
