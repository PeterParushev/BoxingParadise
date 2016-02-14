using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace BoxingParadiseBackend.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = "Repositories\\Migrations";
            TargetDatabase = new DbConnectionInfo("BoxingParadise");
        }

        protected override void Seed(DatabaseContext context)
        {
        }
    }
}