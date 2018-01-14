namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ptid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pfeps", "PartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Pfeps", "PartType_PartTypeId", c => c.Int());
            CreateIndex("dbo.Pfeps", "PartType_PartTypeId");
            AddForeignKey("dbo.Pfeps", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
            DropColumn("dbo.Pfeps", "PartType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pfeps", "PartType", c => c.String());
            DropForeignKey("dbo.Pfeps", "PartType_PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.Pfeps", new[] { "PartType_PartTypeId" });
            DropColumn("dbo.Pfeps", "PartType_PartTypeId");
            DropColumn("dbo.Pfeps", "PartTypeId");
        }
    }
}
