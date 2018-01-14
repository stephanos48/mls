namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delchoil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "ChOil_ChOilId", "dbo.ChOils");
            DropForeignKey("dbo.Files", "ChOils_ChOilId", "dbo.ChOils");
            DropIndex("dbo.FilePaths", new[] { "ChOil_ChOilId" });
            DropIndex("dbo.Files", new[] { "ChOils_ChOilId" });
            DropColumn("dbo.FilePaths", "ChOil_ChOilId");
            DropColumn("dbo.Files", "ChOils_ChOilId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "ChOils_ChOilId", c => c.Int());
            AddColumn("dbo.FilePaths", "ChOil_ChOilId", c => c.Int());
            CreateIndex("dbo.Files", "ChOils_ChOilId");
            CreateIndex("dbo.FilePaths", "ChOil_ChOilId");
            AddForeignKey("dbo.Files", "ChOils_ChOilId", "dbo.ChOils", "ChOilId");
            AddForeignKey("dbo.FilePaths", "ChOil_ChOilId", "dbo.ChOils", "ChOilId");
        }
    }
}
