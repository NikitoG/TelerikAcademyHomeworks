namespace ArticlesTradeCompany
{
    using System;

    using Wintellect.PowerCollections;

    public class Startup
    {
        private const int NumberOfArticles = 1000000;
        private const int MinLength = 3;
        private const int MaxLength = 10;
        private const int BarcodeLength = 10;

        private static readonly OrderedMultiDictionary<decimal, Article> Articles = new OrderedMultiDictionary<decimal, Article>(false);

        public static void Main()
        {

            for (int i = 0; i < NumberOfArticles; i++)
            {
                var article = new Article()
                {
                    Title = RandomGenerator.GetRandomString(RandomGenerator.GetRandomNumber(MinLength, MaxLength), false),
                    Vendor = RandomGenerator.GetRandomString(RandomGenerator.GetRandomNumber(MinLength, MaxLength), false),
                    Barcode = RandomGenerator.GetRandomString(BarcodeLength, true),
                    Price = RandomGenerator.GetRandomDecimal()
                };

                Articles.Add(article.Price, article);
            }

            var fromPrice = 1.25M;
            var toPrice = 1.25M;
            var result = Articles.Range(fromPrice, true, toPrice, true);

            foreach (var article in result)
            {
                Console.WriteLine(article);
            }
        }
    }
}
        