namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wov2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WoOrderStatus",
                c => new
                    {
                        WoOrderStatusId = c.Int(nullable: false, identity: true),
                        WoOrderStatusName = c.String(),
                    })
                .PrimaryKey(t => t.WoOrderStatusId);
            
            AddColumn("dbo.WorkOrders", "WorkOrderNumber", c => c.String());
            AddColumn("dbo.WorkOrders", "CloseDate", c => c.DateTime());
            AddColumn("dbo.WorkOrders", "WoOrderStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.WorkOrders", "WoOrderStatus_WoOrderStatusId", c => c.Int());
            CreateIndex("dbo.WorkOrders", "WoOrderStatus_WoOrderStatusId");
            AddForeignKey("dbo.WorkOrders", "WoOrderStatus_WoOrderStatusId", "dbo.WoOrderStatus", "WoOrderStatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "WoOrderStatus_WoOrderStatusId", "dbo.WoOrderStatus");
            DropIndex("dbo.WorkOrders", new[] { "WoOrderStatus_WoOrderStatusId" });
            DropColumn("dbo.WorkOrders", "WoOrderStatus_WoOrderStatusId");
            DropColumn("dbo.WorkOrders", "WoOrderStatusId");
            DropColumn("dbo.WorkOrders", "CloseDate");
            DropColumn("dbo.WorkOrders", "WorkOrderNumber");
            DropTable("dbo.WoOrderStatus");
        }
    }
}
