namespace DayOfWeekClient
{
    using System;
    using DayOfWeekClient.DayOfWeekServiceReference;

    public class Startup
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DayOfWeekServiceClient client = new DayOfWeekServiceClient();

            var today = DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                var currentDay = today.AddDays(-i);
                var dayName = client.GetDay(currentDay);
                Console.WriteLine(dayName);
            }
        }
    }
}
