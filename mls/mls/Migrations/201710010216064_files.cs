namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ChOils_ChOilId = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.ChOils", t => t.ChOils_ChOilId)
                .Index(t => t.ChOils_ChOilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "ChOils_ChOilId", "dbo.ChOils");
            DropIndex("dbo.Files", new[] { "ChOils_ChOilId" });
            DropTable("dbo.Files");
        }
    }
}
