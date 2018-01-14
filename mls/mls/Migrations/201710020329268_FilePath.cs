namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePath : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        ChOil_ChOilId = c.Int(),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.ChOils", t => t.ChOil_ChOilId)
                .Index(t => t.ChOil_ChOilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "ChOil_ChOilId", "dbo.ChOils");
            DropIndex("dbo.FilePaths", new[] { "ChOil_ChOilId" });
            DropTable("dbo.FilePaths");
        }
    }
}
