namespace DayOfTheWeek
{
    using System;
    using System.Globalization;

    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDay(DateTime date)
        {
            var culture = new CultureInfo("bg-BG");
            return culture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }
    }
}
