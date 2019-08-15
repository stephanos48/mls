namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipplancreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipPlans",
                c => new
                    {
                        ShipPlanId = c.Int(nullable: false, identity: true),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerOrderNo = c.String(nullable: false),
                        CustomerOrderLine = c.String(),
                        SoNumber = c.String(),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ShipQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ShipDateTime = c.DateTime(),
                        OrderStatusId = c.Byte(nullable: false),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        ShipToAddress = c.String(),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        OrderStatus_OrderStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ShipPlanId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_OrderStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.OrderStatus_OrderStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipPlans", "OrderStatus_OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.ShipPlans", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.ShipPlans", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ShipPlans", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.ShipPlans", new[] { "OrderStatus_OrderStatusId" });
            DropIndex("dbo.ShipPlans", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.ShipPlans", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ShipPlans", new[] { "Customer_CustomerId" });
            DropTable("dbo.ShipPlans");
        }
    }
}
