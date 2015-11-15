namespace DayOfTheWeek
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        string GetDay(DateTime date);
    }
}
