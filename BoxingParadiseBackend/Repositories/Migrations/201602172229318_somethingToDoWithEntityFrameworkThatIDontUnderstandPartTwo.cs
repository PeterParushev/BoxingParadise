namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingToDoWithEntityFrameworkThatIDontUnderstandPartTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tBoxer", "Match_Id", c => c.Int());
            CreateIndex("dbo.tBoxer", "Match_Id");
            AddForeignKey("dbo.tBoxer", "Match_Id", "dbo.tMatch", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tBoxer", "Match_Id", "dbo.tMatch");
            DropIndex("dbo.tBoxer", new[] { "Match_Id" });
            DropColumn("dbo.tBoxer", "Match_Id");
        }
    }
}
