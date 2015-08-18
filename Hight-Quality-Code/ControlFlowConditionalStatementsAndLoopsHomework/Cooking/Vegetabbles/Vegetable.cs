namespace Cooking.Vegetabbles
{
    using System;

    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsPeeled = false;
            this.IsCut = false;
        }

        public bool IsPeeled { get; set; }

        public bool IsCut { get; set; }

        public void Peel()
        {
            this.IsPeeled = true;
        }

        public void Cut()
        {
            this.IsPeeled = true;
        }
    }
}
