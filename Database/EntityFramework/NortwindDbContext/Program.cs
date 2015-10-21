namespace NortwindDbContext
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                db.Categories
                    .Select(c => c.CategoryName)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));
                Console.WriteLine("Problem 1: Done :)");
            }

            TestDao();
            Console.WriteLine(new String('-', 40));

            GetAllCusomersWithOrderIn1997ToCanada();
            Console.WriteLine(new String('-', 40));

            GetAllCusomersWithOrderIn1997ToCanadaUsingSQL();
            Console.WriteLine(new String('-', 40));
            
            FindAllOrdersByRegionAndDates("wa", new DateTime(1997, 10, 1), new DateTime(1998, 9, 30));
            Console.WriteLine(new String('-', 40));

            DifferentDataContext();
            Console.WriteLine(new String('-', 40));
        }

        private static void TestDao()
        {
            var customer = new Customer()
            {
                CustomerID = "QWER",
                CompanyName = "Telerik Academy",
                ContactName = "Pesho Peshov",
                City = "Sofia",
                Country = "Bulgaria"
            };

            DAO.InsertCustomer(customer);
            Console.WriteLine("Insert customer - succesfull!");

            DAO.ModifyCustomer(customer.CustomerID, "PostalCode", "1000");
            Console.WriteLine("Customer with id {0} is modify successfully!", customer.CustomerID);

            DAO.DeleteCustomerById(customer.CustomerID);
            Console.WriteLine("Customer with id {0} is deleted!", customer.CustomerID);
        }

        private static void GetAllCusomersWithOrderIn1997ToCanada()
        {
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers
                    .Where(c => c.Orders.Any(o => (o.OrderDate.Value.Year == 1997 && o.ShipCountry.ToLower() == "canada")))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.ContactName));
            }
        }

        private static void GetAllCusomersWithOrderIn1997ToCanadaUsingSQL()
        {
            var query = @"SELECT DISTINCT(c.ContactName)
                            FROM Customers c
	                            JOIN Orders o
	                            ON c.CustomerID = o.CustomerID
                            WHERE YEAR(o.OrderDate) = '1997' AND o.ShipCountry = 'Canada'";
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Database
                    .SqlQuery<string>(query)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));
            }
        }

        private static void FindAllOrdersByRegionAndDates(string region, DateTime startDate, DateTime endDate)
        {
            using(var dbContext = new NorthwindEntities())
            {
                dbContext.Orders
                    .Where(o => (o.ShipRegion.ToLower() == region) && o.OrderDate > startDate && o.OrderDate < endDate)
                    .Select(o => new { o.OrderDate, o.ShipRegion })
                    .ToList()
                    .ForEach(c => Console.WriteLine("{0} - {1}", c.OrderDate, c.ShipRegion));
            }
        }

        static void DifferentDataContext()
        {
            using(var dbFirst = new NorthwindEntities())
            {
                using(var dbSecond = new NorthwindEntities())
                {
                    var firstProduct = dbFirst.Products.FirstOrDefault();
                    firstProduct.UnitsInStock = 25;

                    var secondProduct = dbSecond.Products.FirstOrDefault();
                    secondProduct.UnitsInStock = 15;

                    dbFirst.SaveChanges();
                    dbSecond.SaveChanges();
                }
            }

            using (var dbFirst = new NorthwindEntities())
            {
                using (var dbSecond = new NorthwindEntities())
                {
                    var firstProduct = dbFirst.Products.FirstOrDefault();

                    Console.WriteLine(firstProduct.UnitsInStock);
                }
            }
        }
    }
}
