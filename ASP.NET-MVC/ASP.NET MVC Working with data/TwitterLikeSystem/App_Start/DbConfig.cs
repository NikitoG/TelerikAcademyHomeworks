
namespace TwitterLikeSystem.App_Start
{
    using Data;
    using System.Data.Entity;
    using TwitterLikeSystem.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            DataContext.Create().Database.Initialize(true);
        }
    }
}