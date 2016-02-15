namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tBet", "Boxer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.tBet", "Match_Id", c => c.Int(nullable: false));
            AddColumn("dbo.tBet", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "BoxerOne_Id", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "BoxerTwo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "Venue_Id", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "Winner_Id", c => c.Int());
            CreateIndex("dbo.tBet", "Boxer_Id");
            CreateIndex("dbo.tBet", "Match_Id");
            CreateIndex("dbo.tBet", "User_Id");
            CreateIndex("dbo.tMatch", "BoxerOne_Id");
            CreateIndex("dbo.tMatch", "BoxerTwo_Id");
            CreateIndex("dbo.tMatch", "Venue_Id");
            CreateIndex("dbo.tMatch", "Winner_Id");
            AddForeignKey("dbo.tBet", "Boxer_Id", "dbo.tBoxer", "Id");
            AddForeignKey("dbo.tMatch", "BoxerOne_Id", "dbo.tBoxer", "Id");
            AddForeignKey("dbo.tMatch", "BoxerTwo_Id", "dbo.tBoxer", "Id");
            AddForeignKey("dbo.tMatch", "Venue_Id", "dbo.tVenue", "Id");
            AddForeignKey("dbo.tMatch", "Winner_Id", "dbo.tBoxer", "Id");
            AddForeignKey("dbo.tBet", "Match_Id", "dbo.tMatch", "Id");
            AddForeignKey("dbo.tBet", "User_Id", "dbo.tUser", "Id");
            DropColumn("dbo.tBet", "Fk_tUser_UserId");
            DropColumn("dbo.tBet", "Fk_tMatch_MatchId");
            DropColumn("dbo.tBet", "Fk_tBoxer_PredictionId");
            DropColumn("dbo.tMatch", "Fk_tBoxer_BoxerOneId");
            DropColumn("dbo.tMatch", "Fk_tBoxer_BoxerTwoId");
            DropColumn("dbo.tMatch", "Fk_tVenue_VenueId");
            DropColumn("dbo.tMatch", "Fk_tBoxer_WinnerId");
        }

        public override void Down()
        {
            AddColumn("dbo.tMatch", "Fk_tBoxer_WinnerId", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "Fk_tVenue_VenueId", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "Fk_tBoxer_BoxerTwoId", c => c.Int(nullable: false));
            AddColumn("dbo.tMatch", "Fk_tBoxer_BoxerOneId", c => c.Int(nullable: false));
            AddColumn("dbo.tBet", "Fk_tBoxer_PredictionId", c => c.Int(nullable: false));
            AddColumn("dbo.tBet", "Fk_tMatch_MatchId", c => c.Int(nullable: false));
            AddColumn("dbo.tBet", "Fk_tUser_UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tBet", "User_Id", "dbo.tUser");
            DropForeignKey("dbo.tBet", "Match_Id", "dbo.tMatch");
            DropForeignKey("dbo.tMatch", "Winner_Id", "dbo.tBoxer");
            DropForeignKey("dbo.tMatch", "Venue_Id", "dbo.tVenue");
            DropForeignKey("dbo.tMatch", "BoxerTwo_Id", "dbo.tBoxer");
            DropForeignKey("dbo.tMatch", "BoxerOne_Id", "dbo.tBoxer");
            DropForeignKey("dbo.tBet", "Boxer_Id", "dbo.tBoxer");
            DropIndex("dbo.tMatch", new[] { "Winner_Id" });
            DropIndex("dbo.tMatch", new[] { "Venue_Id" });
            DropIndex("dbo.tMatch", new[] { "BoxerTwo_Id" });
            DropIndex("dbo.tMatch", new[] { "BoxerOne_Id" });
            DropIndex("dbo.tBet", new[] { "User_Id" });
            DropIndex("dbo.tBet", new[] { "Match_Id" });
            DropIndex("dbo.tBet", new[] { "Boxer_Id" });
            DropColumn("dbo.tMatch", "Winner_Id");
            DropColumn("dbo.tMatch", "Venue_Id");
            DropColumn("dbo.tMatch", "BoxerTwo_Id");
            DropColumn("dbo.tMatch", "BoxerOne_Id");
            DropColumn("dbo.tBet", "User_Id");
            DropColumn("dbo.tBet", "Match_Id");
            DropColumn("dbo.tBet", "Boxer_Id");
        }
    }
}