namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateincomingdetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId", "dbo.IncomingTopLevels");
            DropIndex("dbo.IncomingDetails", new[] { "IncomingTopLevel_IncomingTopLevelId" });
            RenameColumn(table: "dbo.IncomingDetails", name: "IncomingTopLevel_IncomingTopLevelId", newName: "IncomingTopLevelId");
            AlterColumn("dbo.IncomingDetails", "IncomingTopLevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.IncomingDetails", "IncomingTopLevelId");
            AddForeignKey("dbo.IncomingDetails", "IncomingTopLevelId", "dbo.IncomingTopLevels", "IncomingTopLevelId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomingDetails", "IncomingTopLevelId", "dbo.IncomingTopLevels");
            DropIndex("dbo.IncomingDetails", new[] { "IncomingTopLevelId" });
            AlterColumn("dbo.IncomingDetails", "IncomingTopLevelId", c => c.Int());
            RenameColumn(table: "dbo.IncomingDetails", name: "IncomingTopLevelId", newName: "IncomingTopLevel_IncomingTopLevelId");
            CreateIndex("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId");
            AddForeignKey("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId", "dbo.IncomingTopLevels", "IncomingTopLevelId");
        }
    }
}
