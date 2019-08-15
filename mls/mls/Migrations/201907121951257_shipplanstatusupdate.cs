namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipplanstatusupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShipPlans", "OrderStatus_OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.ShipPlans", new[] { "OrderStatus_OrderStatusId" });
            CreateTable(
                "dbo.ShipPlanStatus",
                c => new
                    {
                        ShipPlanStatusId = c.Int(nullable: false, identity: true),
                        ShipPlanStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ShipPlanStatusId);
            
            AddColumn("dbo.ShipPlans", "ShipPlanStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.ShipPlans", "ShipPlanStatus_ShipPlanStatusId", c => c.Int());
            CreateIndex("dbo.ShipPlans", "ShipPlanStatus_ShipPlanStatusId");
            AddForeignKey("dbo.ShipPlans", "ShipPlanStatus_ShipPlanStatusId", "dbo.ShipPlanStatus", "ShipPlanStatusId");
            DropColumn("dbo.ShipPlans", "OrderStatusId");
            DropColumn("dbo.ShipPlans", "OrderStatus_OrderStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShipPlans", "OrderStatus_OrderStatusId", c => c.Int());
            AddColumn("dbo.ShipPlans", "OrderStatusId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.ShipPlans", "ShipPlanStatus_ShipPlanStatusId", "dbo.ShipPlanStatus");
            DropIndex("dbo.ShipPlans", new[] { "ShipPlanStatus_ShipPlanStatusId" });
            DropColumn("dbo.ShipPlans", "ShipPlanStatus_ShipPlanStatusId");
            DropColumn("dbo.ShipPlans", "ShipPlanStatusId");
            DropTable("dbo.ShipPlanStatus");
            CreateIndex("dbo.ShipPlans", "OrderStatus_OrderStatusId");
            AddForeignKey("dbo.ShipPlans", "OrderStatus_OrderStatusId", "dbo.OrderStatus", "OrderStatusId");
        }
    }
}
