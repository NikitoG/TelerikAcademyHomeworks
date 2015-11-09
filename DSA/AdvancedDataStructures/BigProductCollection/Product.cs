using System;
namespace BigProductCollection
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Name + " - " + this.Price;
        }
    }
}
