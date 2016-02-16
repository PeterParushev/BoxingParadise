namespace BoxingParadiseBackend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpiryDate = c.DateTime(nullable: false),
                        Key = c.String(nullable: false, maxLength: 10),
                        IsExpired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tLogin");
        }
    }
}
