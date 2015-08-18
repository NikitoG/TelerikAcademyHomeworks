namespace CSharpOneExam
{
    using System;

    public class MoneySave
    {
        public static void Main()
        {
            const decimal SheetsInOneRealm = 400;

            decimal numberOfstudents = int.Parse(Console.ReadLine());
            decimal sheetsPerStudent = int.Parse(Console.ReadLine());
            decimal pricePerRealm = decimal.Parse(Console.ReadLine());

            decimal totalPaper = numberOfstudents * sheetsPerStudent;
            decimal realmNumber = totalPaper / 400;
            decimal saveMoney = realmNumber * pricePerRealm;

            Console.WriteLine("{0:F3}", saveMoney);
        }
    }
}
