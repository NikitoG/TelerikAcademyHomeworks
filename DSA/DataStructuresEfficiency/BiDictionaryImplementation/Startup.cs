namespace BiDictionaryImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var tuple = new BiDictionary<string, string, string>();

            tuple.Add("Pesho", "Peshov", "pehskata@abv.bg");
            tuple.Add("Gosho", "Goshov", "gogata@abv.bg");
            tuple.Add("Tosho", "Toshov", "tosheto@abv.bg");

            var pesho = tuple.FindByKey1("Pesho");
            Console.WriteLine(pesho);

            var gosho = tuple.FindByKey2("Goshov");
            Console.WriteLine(gosho);

            var tosho = tuple.FindByTwoKeys("Tosho", "Toshov");
            Console.WriteLine(tosho);
        }
    }
}
