namespace ExcelOledDb
{
    using System;
    using System.Data.OleDb;

    class Program
    {
        public static void Main()
        {

            OleDbConnection dbCon =
                new OleDbConnection(@"Provider= Microsoft.ACE.OLEDB.12.0;Data Source = ..\..\excel\results.xlsx;Extended Properties = ""Excel 12.0 Xml;HDR=YES"";");

            dbCon.Open();

            using (dbCon)
            {
                ReadExcelFile(dbCon);
                Console.WriteLine(new String('-', 40));

                AppendNewRow("John Doe", 123, dbCon);
                Console.WriteLine(new String('-', 40));
            }
        }

        // 6. Create an Excel file with 2 columns: name and score:
        //Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.

        private static void ReadExcelFile(OleDbConnection dbCon)
        {
            string command = @"SELECT * FROM [Sheet1$]";

            OleDbCommand getData = new OleDbCommand(command, dbCon);
            OleDbDataReader reader = getData.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var name = reader["Name"];
                    var result = reader["Score"];
                    Console.WriteLine("{0} - {1}", name, result);
                }
            }
        }

        // 7. Implement appending new rows to the Excel file

        private static void AppendNewRow(string name, double score, OleDbConnection dbCon)
        {
            OleDbCommand cmd = new OleDbCommand(string.Format("INSERT INTO [Sheet1$] (Name, Score) VALUES ('{0}', '{1}')", name, score), dbCon);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Appednding new row - successfully.");
            }
            catch (OleDbException exception)
            {
                Console.WriteLine("Excel Error occured: " + exception);
            }
        }
    }
}
