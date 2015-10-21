namespace NorthwindTwin
{
    using NortwindDbContext;

    class Program
    {
        static void Main(string[] args)
        {
            CreateNorthwindTwin();
        }

        private static void CreateNorthwindTwin()
        {
            using(var dbContext = new NorthwindEntities())
            {

                dbContext.Database.CreateIfNotExists();
            }
        }
    }
}
