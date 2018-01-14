namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wov3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrders", "PartType_PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.WorkOrders", new[] { "PartType_PartTypeId" });
            CreateTable(
                "dbo.WoPartTypes",
                c => new
                    {
                        WoPartTypeId = c.Int(nullable: false, identity: true),
                        WoPartTypeName = c.String(),
                    })
                .PrimaryKey(t => t.WoPartTypeId);
            
            AddColumn("dbo.WorkOrders", "WoPartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.WorkOrders", "WoPartType_WoPartTypeId", c => c.Int());
            CreateIndex("dbo.WorkOrders", "WoPartType_WoPartTypeId");
            AddForeignKey("dbo.WorkOrders", "WoPartType_WoPartTypeId", "dbo.WoPartTypes", "WoPartTypeId");
            DropColumn("dbo.WorkOrders", "PartTypeId");
            DropColumn("dbo.WorkOrders", "PartType_PartTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrders", "PartType_PartTypeId", c => c.Int());
            AddColumn("dbo.WorkOrders", "PartTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.WorkOrders", "WoPartType_WoPartTypeId", "dbo.WoPartTypes");
            DropIndex("dbo.WorkOrders", new[] { "WoPartType_WoPartTypeId" });
            DropColumn("dbo.WorkOrders", "WoPartType_WoPartTypeId");
            DropColumn("dbo.WorkOrders", "WoPartTypeId");
            DropTable("dbo.WoPartTypes");
            CreateIndex("dbo.WorkOrders", "PartType_PartTypeId");
            AddForeignKey("dbo.WorkOrders", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
        }
    }
}
