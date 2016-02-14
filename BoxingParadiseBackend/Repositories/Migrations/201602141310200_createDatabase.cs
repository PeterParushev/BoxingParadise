namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tAdministrator",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminKey = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tBet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        BoxerId = c.Int(nullable: false),
                        Canceled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tBoxer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tMatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_tBoxer_BoxerOneId = c.Int(nullable: false),
                        Fk_tBoxer_BoxerTwoId = c.Int(nullable: false),
                        Fk_tVenue_VenueId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Fk_tBoxer_WinnerId = c.Int(nullable: false),
                        Canceled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Rating = c.Double(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tVenue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.tVenue");
            DropTable("dbo.tUser");
            DropTable("dbo.tMatch");
            DropTable("dbo.tBoxer");
            DropTable("dbo.tBet");
            DropTable("dbo.tAdministrator");
        }
    }
}