namespace SubStringOccuranceConsumer
{
    using System;
    using SubStringOccuranceConsumer.ServiceReference1;

    public class Startup
    {
        public static void Main()
        {
            OccuranceServiceClient client = new OccuranceServiceClient();
            var firstString = "nikPeshonikniknik";
            var secondString = "nik";
            var result = client.GetOccurance(firstString, secondString);
            Console.WriteLine("{0} occuarance in {1} - {2} times.", secondString, firstString, result);
        }
    }
}
