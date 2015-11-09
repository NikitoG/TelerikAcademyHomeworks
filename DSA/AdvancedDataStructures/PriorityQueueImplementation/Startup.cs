namespace PriorityQueueImplementation
{
    using System;

    class Startup
    {
        public static void Main()
        {
            PriorityQueue<int> priorityQ = new PriorityQueue<int>();
            priorityQ.Enqueue(1);
            priorityQ.Enqueue(19);
            priorityQ.Enqueue(3);
            priorityQ.Enqueue(100);
            priorityQ.Enqueue(36);
            priorityQ.Enqueue(17);
            priorityQ.Enqueue(2);
            priorityQ.Enqueue(19);
            priorityQ.Enqueue(25);

            while(priorityQ.Count > 0)
            {
                Console.WriteLine(priorityQ.Dequeue());
            }
        }
    }
}
