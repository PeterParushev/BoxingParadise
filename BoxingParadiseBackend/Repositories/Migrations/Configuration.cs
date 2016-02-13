using System.Data.Entity.Migrations;

namespace BoxingParadiseBackend.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BoxingParadiseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BoxingParadiseContext context)
        {
        }
    }
}