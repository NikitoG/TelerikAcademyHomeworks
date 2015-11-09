namespace BigProductCollection
{
    using System;
    using Wintellect.PowerCollections;

    class Startup
    {
        static readonly Random random = new Random();

        public static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                var newProduct = new Product()
                {
                    Name = string.Format("Product #{0}", i + 1),
                    Price = Math.Round((decimal)(random.NextDouble() * 10000), 2)
                };

                products.Add(newProduct);
            }


            var priceFrom = 999;
            var PriceTo = 1000;
            Console.WriteLine("Sub-range [{0}...{1}]: ", priceFrom, PriceTo);
            var result = products.Range(new Product() { Price = priceFrom }, true, new Product() { Price = PriceTo}, true);

            foreach(var product in result)
            {
                Console.WriteLine(product);
            }
        }

    }
}
