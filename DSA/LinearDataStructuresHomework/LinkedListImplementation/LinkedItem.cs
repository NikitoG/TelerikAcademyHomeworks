namespace LinkedListImplementation
{
    using System;
    using System.Linq;

    public class LinkedItem<T>
    {

        public LinkedItem(T value, LinkedItem<T> nextItem = null)
        {
            this.Value = value;
            this.NextItem = nextItem;
        }

        public T Value { get; set; }

        public LinkedItem<T> NextItem { get; set; }
    }
}
