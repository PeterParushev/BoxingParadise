namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iHaveNoIdeaHowEFWorks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tBoxer", "Match_Id", "dbo.tMatch");
            DropForeignKey("dbo.tMatch", "Boxer_Id", "dbo.tBoxer");
            DropIndex("dbo.tBoxer", new[] { "Match_Id" });
            DropIndex("dbo.tMatch", new[] { "Boxer_Id" });
            RenameColumn(table: "dbo.tBet", name: "Boxer_Id", newName: "BoxerId");
            RenameColumn(table: "dbo.tBet", name: "Match_Id", newName: "MatchId");
            RenameColumn(table: "dbo.tBet", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.tMatch", name: "BoxerOne_Id", newName: "BoxerOneId");
            RenameColumn(table: "dbo.tMatch", name: "BoxerTwo_Id", newName: "BoxerTwoId");
            RenameColumn(table: "dbo.tMatch", name: "Venue_Id", newName: "VenueId");
            RenameColumn(table: "dbo.tMatch", name: "Winner_Id", newName: "WinnerId");
            RenameIndex(table: "dbo.tBet", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.tBet", name: "IX_Match_Id", newName: "IX_MatchId");
            RenameIndex(table: "dbo.tBet", name: "IX_Boxer_Id", newName: "IX_BoxerId");
            RenameIndex(table: "dbo.tMatch", name: "IX_BoxerOne_Id", newName: "IX_BoxerOneId");
            RenameIndex(table: "dbo.tMatch", name: "IX_BoxerTwo_Id", newName: "IX_BoxerTwoId");
            RenameIndex(table: "dbo.tMatch", name: "IX_Venue_Id", newName: "IX_VenueId");
            RenameIndex(table: "dbo.tMatch", name: "IX_Winner_Id", newName: "IX_WinnerId");
            DropColumn("dbo.tBoxer", "Match_Id");
            DropColumn("dbo.tMatch", "Boxer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tMatch", "Boxer_Id", c => c.Int());
            AddColumn("dbo.tBoxer", "Match_Id", c => c.Int());
            RenameIndex(table: "dbo.tMatch", name: "IX_WinnerId", newName: "IX_Winner_Id");
            RenameIndex(table: "dbo.tMatch", name: "IX_VenueId", newName: "IX_Venue_Id");
            RenameIndex(table: "dbo.tMatch", name: "IX_BoxerTwoId", newName: "IX_BoxerTwo_Id");
            RenameIndex(table: "dbo.tMatch", name: "IX_BoxerOneId", newName: "IX_BoxerOne_Id");
            RenameIndex(table: "dbo.tBet", name: "IX_BoxerId", newName: "IX_Boxer_Id");
            RenameIndex(table: "dbo.tBet", name: "IX_MatchId", newName: "IX_Match_Id");
            RenameIndex(table: "dbo.tBet", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.tMatch", name: "WinnerId", newName: "Winner_Id");
            RenameColumn(table: "dbo.tMatch", name: "VenueId", newName: "Venue_Id");
            RenameColumn(table: "dbo.tMatch", name: "BoxerTwoId", newName: "BoxerTwo_Id");
            RenameColumn(table: "dbo.tMatch", name: "BoxerOneId", newName: "BoxerOne_Id");
            RenameColumn(table: "dbo.tBet", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.tBet", name: "MatchId", newName: "Match_Id");
            RenameColumn(table: "dbo.tBet", name: "BoxerId", newName: "Boxer_Id");
            CreateIndex("dbo.tMatch", "Boxer_Id");
            CreateIndex("dbo.tBoxer", "Match_Id");
            AddForeignKey("dbo.tMatch", "Boxer_Id", "dbo.tBoxer", "Id");
            AddForeignKey("dbo.tBoxer", "Match_Id", "dbo.tMatch", "Id");
        }
    }
}
