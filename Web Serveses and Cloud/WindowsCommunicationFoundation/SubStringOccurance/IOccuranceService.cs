namespace SubStringOccurance
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IOccuranceService
    {
        [OperationContract]
        int GetOccurance(string first, string second);
    }
}
