namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addDeletedToBoxerAndVenue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tBoxer", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.tVenue", "Deleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.tVenue", "Deleted");
            DropColumn("dbo.tBoxer", "Deleted");
        }
    }
}