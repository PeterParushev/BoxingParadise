namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingToDoWithEntityFrameworkThatIDontUnderstand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tMatch", "Boxer_Id", c => c.Int());
            CreateIndex("dbo.tMatch", "Boxer_Id");
            AddForeignKey("dbo.tMatch", "Boxer_Id", "dbo.tBoxer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tMatch", "Boxer_Id", "dbo.tBoxer");
            DropIndex("dbo.tMatch", new[] { "Boxer_Id" });
            DropColumn("dbo.tMatch", "Boxer_Id");
        }
    }
}
