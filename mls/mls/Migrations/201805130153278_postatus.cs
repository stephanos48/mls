namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders", "OrderStatus_OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.PurchaseOrders", new[] { "OrderStatus_OrderStatusId" });
            CreateTable(
                "dbo.PoOrderStatus",
                c => new
                    {
                        PoOrderStatusId = c.Int(nullable: false, identity: true),
                        PoOrderStatusName = c.String(),
                    })
                .PrimaryKey(t => t.PoOrderStatusId);
            
            AddColumn("dbo.PurchaseOrders", "PoOrderStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.PurchaseOrders", "PoOrderStatus_PoOrderStatusId", c => c.Int());
            CreateIndex("dbo.PurchaseOrders", "PoOrderStatus_PoOrderStatusId");
            AddForeignKey("dbo.PurchaseOrders", "PoOrderStatus_PoOrderStatusId", "dbo.PoOrderStatus", "PoOrderStatusId");
            DropColumn("dbo.PurchaseOrders", "OrderStatusId");
            DropColumn("dbo.PurchaseOrders", "OrderStatus_OrderStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "OrderStatus_OrderStatusId", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "OrderStatusId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.PurchaseOrders", "PoOrderStatus_PoOrderStatusId", "dbo.PoOrderStatus");
            DropIndex("dbo.PurchaseOrders", new[] { "PoOrderStatus_PoOrderStatusId" });
            DropColumn("dbo.PurchaseOrders", "PoOrderStatus_PoOrderStatusId");
            DropColumn("dbo.PurchaseOrders", "PoOrderStatusId");
            DropTable("dbo.PoOrderStatus");
            CreateIndex("dbo.PurchaseOrders", "OrderStatus_OrderStatusId");
            AddForeignKey("dbo.PurchaseOrders", "OrderStatus_OrderStatusId", "dbo.OrderStatus", "OrderStatusId");
        }
    }
}
