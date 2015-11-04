namespace LinkedListImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            LinkedList<int> test = new LinkedList<int>();

            test.AddFirst(3);
            test.AddFirst(2);
            test.AddLast(1);
            test.AddLast(4);
            test.RemoveFirst();
            test.RemoveLast();

            var index = 1;

            foreach (var item in test)
            {
                Console.WriteLine("Item #{0}: {1}", index, item);
                index++;
            }

            Console.WriteLine("LinkedList.Count: {0}", test.Count());
        }
    }
}
