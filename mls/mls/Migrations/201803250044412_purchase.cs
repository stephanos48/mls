namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false, identity: true),
                        PoNumber = c.String(),
                        SupplierId = c.Byte(nullable: false),
                        ShipToAddress = c.String(),
                        ConfirmTo = c.String(),
                        ShipVia = c.String(),
                        FOB = c.String(),
                        Terms = c.String(),
                        Reference = c.String(),
                        CustomerOrderNumber = c.String(nullable: false),
                        SoNumber = c.String(),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        PartPrice = c.Decimal(precision: 18, scale: 2),
                        OrderQty = c.Int(nullable: false),
                        ReceivedQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ReceiptDateTime = c.DateTime(),
                        OrderStatusId = c.Byte(nullable: false),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        OrderStatus_OrderStatusId = c.Int(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_OrderStatusId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.OrderStatus_OrderStatusId)
                .Index(t => t.Supplier_SupplierId);
            
            AddColumn("dbo.ShipIns", "PoNo", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrders", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "OrderStatus_OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.PurchaseOrders", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.PurchaseOrders", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.PurchaseOrders", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.PurchaseOrders", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "OrderStatus_OrderStatusId" });
            DropIndex("dbo.PurchaseOrders", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.PurchaseOrders", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.PurchaseOrders", new[] { "Customer_CustomerId" });
            DropColumn("dbo.ShipIns", "PoNo");
            DropTable("dbo.PurchaseOrders");
        }
    }
}
