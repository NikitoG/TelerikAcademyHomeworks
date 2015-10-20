namespace RetrievsDataFromMSSQL
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        public static void Main()
        {
            SqlConnection dbCon =
                new SqlConnection(@"Server=.; Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                int numberOfRows = RetrieveNumberOfRowsInCategoriesFromNortwind(dbCon);
                Console.WriteLine("Number of rows in Categories: {0}", numberOfRows);
                Console.WriteLine(new String('-', 40));

                RetrieveNamesAndDescriptionOfAllCategories(dbCon);
                Console.WriteLine(new String('-', 40));

                RetrieveAllCategoriesAndProducts(dbCon);
                Console.WriteLine(new String('-', 40));

                int id = AddNewProduct("Rakiq", 4, 3, "6x700", 8.00M, 18, 24, 2, true, dbCon);
                Console.WriteLine("Added new product with id: " + id);
                Console.WriteLine(new String('-', 40));

                GetAllImages(dbCon);
                Console.WriteLine("All images are in pictures folder!");
                Console.WriteLine(new String('-', 40));

                Console.WriteLine("Enter pattern for serching product.");
                var pattern = Console.ReadLine();
                GetAllProductsThatContainsPattern(pattern, dbCon);
                Console.WriteLine(new String('-', 40));
            }
        }

        //1.Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.

        private static int RetrieveNumberOfRowsInCategoriesFromNortwind(SqlConnection dbCon)
        {
            SqlCommand getRows = new SqlCommand(
                  "SELECT COUNT(*) FROM Categories", dbCon);
            int numberOfRows = (int)getRows.ExecuteScalar();

            return numberOfRows;
        }

        //2.Write a program that retrieves the name and description of all categories in the Northwind DB.

        private static void RetrieveNamesAndDescriptionOfAllCategories(SqlConnection dbCon)
        {
            SqlCommand getNamesAndDescrition = new SqlCommand(
                  "SELECT CategoryName, Description FROM Categories", dbCon);

            SqlDataReader reader = getNamesAndDescrition.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", name, description);
                }
            }
        }

        //3.Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
        //Can you do this with a single SQL query (with table join)?

        private static void RetrieveAllCategoriesAndProducts(SqlConnection dbCon)
        {
            var command = @"SELECT c.CategoryName, p.ProductName
                            FROM Products p
	                            JOIN Categories c
	                            ON p.CategoryID = c.CategoryID
                            ORDER BY c.CategoryName";
            SqlCommand getNamesAndProducts = new SqlCommand(
                  command, dbCon);

            SqlDataReader reader = getNamesAndProducts.ExecuteReader();
            using (reader)
            {
                var tempCategory = String.Empty;
                while (reader.Read())
                {
                    string category = (string)reader["CategoryName"];
                    string product = (string)reader["ProductName"];
                    if (tempCategory == category)
                    {
                        Console.WriteLine("{0} - {1}", new String(' ', category.Length), product);
                    }
                    else
                    {
                        Console.WriteLine("{0} - {1}", category, product);
                        tempCategory = category;
                    }
                }
            }
        }

        //4. Write a method that adds a new product in the products table in the Northwind database.
        //Use a parameterized SQL command.

        private static int AddNewProduct(
            string productName,
            int? supplierID,
            int? categoryID,
            string quantityPerUnit,
            decimal? unitPrice,
            short? unitsInStock,
            short? unitsOnOrder,
            short? reorderLevel,
            bool discontinued, SqlConnection dbCon)
        {
            string command = @"
                    INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder,ReorderLevel, Discontinued)
                    VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @nitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

            SqlCommand cmdInsertCommand = new SqlCommand(command, dbCon);
            cmdInsertCommand.Parameters.AddWithValue("@productName", productName);
            cmdInsertCommand.Parameters.AddWithValue("@supplierID", supplierID);
            cmdInsertCommand.Parameters.AddWithValue("@categoryID", categoryID);
            cmdInsertCommand.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdInsertCommand.Parameters.AddWithValue("@nitPrice", unitPrice);
            cmdInsertCommand.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmdInsertCommand.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmdInsertCommand.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmdInsertCommand.Parameters.AddWithValue("@discontinued", discontinued);

            cmdInsertCommand.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        //5. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.

        private static void GetAllImages(SqlConnection dbCon)
        {
            SqlCommand getImages = new SqlCommand(
                "SELECT CategoryName, Picture FROM Categories", dbCon);

            SqlDataReader reader = getImages.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var name = (string)reader["CategoryName"];
                    name = name.Replace('/', '_');
                    var image = (byte[])reader["Picture"];
                    string fileName = string.Format(@"..\..\pictures\{0}.jpg", name);
                    WriteBinaryFile(fileName, image);
                }
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }

        //8. Write a program that reads a string from the console and finds all products that contain this string.
        //    Ensure you handle correctly characters like ', %, ", \ and _.

        private static void GetAllProductsThatContainsPattern(string pattern, SqlConnection dbCon)
        {
            string command = @"
                    SELECT ProductName
                    FROM Products
                    WHERE ProductName LIKE '%' + @pattern + '%'";

            SqlCommand allProducts = new SqlCommand(command, dbCon);
            allProducts.Parameters.AddWithValue("@pattern", pattern);
            SqlDataReader reader = allProducts.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0}", productName);
                }
            }
        }
    }
}
