namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        SupportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supports", t => t.SupportId, cascadeDelete: true)
                .Index(t => t.SupportId);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Summary = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.SupportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDetails", "SupportId", "dbo.Supports");
            DropIndex("dbo.FileDetails", new[] { "SupportId" });
            DropTable("dbo.Supports");
            DropTable("dbo.FileDetails");
        }
    }
}
