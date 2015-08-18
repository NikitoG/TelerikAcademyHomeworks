namespace Cooking
{
    using System;
    using System.Collections.Generic;

    using Cooking.Vegetabbles;

    public class Bowl
    {
        public Bowl()
        {
            this.Ingrediants = new List<Vegetable>();
        }

        public List<Vegetable> Ingrediants { get; set; }

        public void Add(Vegetable vegetable)
        {
            this.Ingrediants.Add(vegetable);
        }
    }
}
