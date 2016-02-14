namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tBet", name: "UserId", newName: "Fk_tUser_UserId");
            RenameColumn(table: "dbo.tBet", name: "MatchId", newName: "Fk_tMatch_MatchId");
            RenameColumn(table: "dbo.tBet", name: "BoxerId", newName: "Fk_tBoxer_PredictionId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.tBet", name: "Fk_tBoxer_PredictionId", newName: "BoxerId");
            RenameColumn(table: "dbo.tBet", name: "Fk_tMatch_MatchId", newName: "MatchId");
            RenameColumn(table: "dbo.tBet", name: "Fk_tUser_UserId", newName: "UserId");
        }
    }
}
