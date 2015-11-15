namespace SubStringOccurance
{
    using System;

    public class OccuranceService : IOccuranceService
    {
        public int GetOccurance(string first, string second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("The value cannot be null!");
            }

            int result = 0;
            int start = 0;

            while (true)
            {
                var index = first.IndexOf(second, start);
                if (index >= 0)
                {
                    result++;
                    start = index + 1;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
