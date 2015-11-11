namespace ArticlesTradeCompany
{
    using System;

    public class Article : IComparable<Article>
    {
        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Title, this.Vendor);
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
