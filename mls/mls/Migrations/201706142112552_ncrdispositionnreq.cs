namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncrdispositionnreq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterPartLists", "PartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.MasterPartLists", "PartType_PartTypeId", c => c.Int());
            AlterColumn("dbo.NCRs", "DispositionId", c => c.Byte());
            CreateIndex("dbo.MasterPartLists", "PartType_PartTypeId");
            AddForeignKey("dbo.MasterPartLists", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
            DropColumn("dbo.MasterPartLists", "PartType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MasterPartLists", "PartType", c => c.String());
            DropForeignKey("dbo.MasterPartLists", "PartType_PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.MasterPartLists", new[] { "PartType_PartTypeId" });
            AlterColumn("dbo.NCRs", "DispositionId", c => c.Byte(nullable: false));
            DropColumn("dbo.MasterPartLists", "PartType_PartTypeId");
            DropColumn("dbo.MasterPartLists", "PartTypeId");
        }
    }
}
