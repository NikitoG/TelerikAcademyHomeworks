namespace MySqlDatabase
{
    using System;
    using System.Configuration;
    using MySql.Data.MySqlClient;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter MySQL password: ");
            string pass = Console.ReadLine();

            string connectionStr = "Server=localhost;Database=Books;Uid=root;Pwd=" + pass + ";";
            MySqlConnection connection = new MySqlConnection(connectionStr);

            GetAllBooks(connectionStr);

            InsertBooks(connectionStr);

            Console.WriteLine("Write pattern for searching book by title:");
            var pattern = Console.ReadLine();
            SearchBookByPattern(pattern, connectionStr);
        }

        private static void GetAllBooks(string connectionStr)
        {
            MySqlConnection dbCon = new MySqlConnection(connectionStr);
            dbCon.Open();

            using (dbCon)
            {
                var command = new MySqlCommand(@"SELECT Title, Author, ISBN, PublishDate FROM book", dbCon);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var title = reader["Title"];
                    var author = reader["Author"];
                    var isbn = reader["ISBN"];
                    var date = (DateTime)reader["PublishDate"];
                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, isbn, date);
                }
            }
        }

        private static void SearchBookByPattern(string input, string connectionStringForMySql)
        {

            var dbCon = new MySqlConnection(connectionStringForMySql);
            dbCon.Open();

            using (dbCon)
            {
                var command = new MySqlCommand(@"SELECT Title FROM book WHERE Title LIKE '%' + @pattern + '%'", dbCon);
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
            MySqlConnection dbCon = new MySqlConnection(connectionStr);
            dbCon.Open();

            var command = new MySqlCommand("INSERT INTO book(Title,Author, PublishDate, ISBN) VALUES (@title,@author,@publishDate,@isbn)", dbCon);
            command.Parameters.AddWithValue("@title", "New Book");
            command.Parameters.AddWithValue("@author", "New Author");
            command.Parameters.AddWithValue("@publishDate", "2015/10/10");
            command.Parameters.AddWithValue("@isbn", "2324-324-34");

            command.ExecuteNonQuery();
        }
    }
}
