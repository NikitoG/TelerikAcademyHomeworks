namespace SQLLiteBook
{
    using System;
    using System.Data.SQLite;

    class Program
    {
        static void Main()
        {
            var connectionStr = "Data Source=../../books.sqlite;Version=3;";

            GetAllBooks(connectionStr);

            InsertBooks(connectionStr);

            Console.WriteLine("Write pattern for searching book by title:");
            var pattern = Console.ReadLine();
            SearchBookByPattern(pattern, connectionStr);
        }

        private static void GetAllBooks(string connectionStr)
        {
            SQLiteConnection dbCon = new SQLiteConnection(connectionStr);
            dbCon.Open();

            using (dbCon)
            {
                var command = new SQLiteCommand("SELECT Title, Author FROM book", dbCon);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var title = reader["Title"];
                    var author = reader["Author"];
                    Console.WriteLine("{0} - {1}", title, author);
                }
            }
        }

        private static void SearchBookByPattern(string input, string connectionStringForMySql)
        {

            var dbCon = new SQLiteConnection(connectionStringForMySql);
            dbCon.Open();

            using (dbCon)
            {
                var command = new SQLiteCommand(@"SELECT Title FROM book WHERE Title LIKE '%' + @pattern + '%'", dbCon);
                command.Parameters.AddWithValue("@pattern", input);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Title"]);
                }
            }
        }

        private static void InsertBooks(string connectionStr)
        {
            var dbCon = new SQLiteConnection(connectionStr);
            dbCon.Open();

            var command = new SQLiteCommand("INSERT INTO book(Title,Author, PublishDate, ISBN) VALUES (@title,@author,@publishDate,@isbn)", dbCon);
            command.Parameters.AddWithValue("@title", "New Book");
            command.Parameters.AddWithValue("@author", "New Author");
            command.Parameters.AddWithValue("@publishDate", DateTime.Now);
            command.Parameters.AddWithValue("@isbn", "2324-324-34");

            command.ExecuteNonQuery();
        }
    }
}
