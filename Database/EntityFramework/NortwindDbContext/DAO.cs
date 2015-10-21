namespace NortwindDbContext
{
    using System;
    using System.Linq;

    class DAO
    {
        public static void InsertCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null!");
            }

            using(var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            }
        }

        public static void ModifyCustomer(string id, string propertyName, string value)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Id cannot be null or contains white space!");
            }

            if(string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("Property name cannot be null!");
            }

            using(var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers
                    .Where(c => c.CustomerID == id)
                    .FirstOrDefault();

                if(customer == null)
                {
                    throw new ArgumentException("Customer with given id not found!");
                }

                dbContext.Entry(customer).Property(propertyName).CurrentValue = value;
                dbContext.SaveChanges();
            }
        }

        public static void DeleteCustomerById(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Id cannot be null or contains white space!");
            }

            using(var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers
                    .Where(c => c.CustomerID == id)
                    .FirstOrDefault();

                if(customer == null)
                {
                    throw new ArgumentException("Customer with given id not found!");
                }

                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }
        }
    }
}
