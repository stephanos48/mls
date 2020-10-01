namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heilupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeilPoes",
                c => new
                    {
                        HeilPoId = c.Int(nullable: false, identity: true),
                        PoNumber = c.String(),
                        PoLine = c.String(),
                        SupplierId = c.Byte(nullable: false),
                        CustomerOrderNumber = c.String(),
                        SoNumber = c.String(),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ReceivedQty = c.Int(),
                        ContainerId = c.String(),
                        ContainerUh = c.String(),
                        FreightFowarder = c.String(),
                        Destination = c.String(),
                        AMS = c.String(),
                        BOL = c.String(),
                        Pallet = c.String(),
                        Invoice = c.String(),
                        ArrivalWk = c.String(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        Shipdate = c.DateTime(),
                        Etadate = c.DateTime(),
                        ReceiptDateTime = c.DateTime(),
                        PoOrderStatusId = c.Byte(nullable: false),
                        PoSentDateTime = c.DateTime(),
                        PoSentBy = c.String(),
                        PoConfirmedDateTime = c.DateTime(),
                        PoConfirmedBy = c.String(),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PoOrderStatus_PoOrderStatusId = c.Int(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.HeilPoId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PoOrderStatus", t => t.PoOrderStatus_PoOrderStatusId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PoOrderStatus_PoOrderStatusId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.HeilQohs",
                c => new
                    {
                        HeilQohId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        Qoh = c.Int(nullable: false),
                        Location = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.HeilQohId);
            
            CreateTable(
                "dbo.HeilShips",
                c => new
                    {
                        HeilShipId = c.Int(nullable: false, identity: true),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerOrderNo = c.String(nullable: false),
                        CustomerOrderLine = c.String(),
                        SoNumber = c.String(),
                        WoNumber = c.String(),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ShipQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ShipDateTime = c.DateTime(),
                        ShipPlanStatusId = c.Byte(nullable: false),
                        CQStatusId = c.Byte(nullable: false),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        ShipToAddress = c.String(),
                        Notes = c.String(),
                        CQStatus_CQStatusId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        ShipPlanStatus_ShipPlanStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.HeilShipId)
                .ForeignKey("dbo.CQStatus", t => t.CQStatus_CQStatusId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.ShipPlanStatus", t => t.ShipPlanStatus_ShipPlanStatusId)
                .Index(t => t.CQStatus_CQStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.ShipPlanStatus_ShipPlanStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HeilShips", "ShipPlanStatus_ShipPlanStatusId", "dbo.ShipPlanStatus");
            DropForeignKey("dbo.HeilShips", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.HeilShips", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.HeilShips", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.HeilShips", "CQStatus_CQStatusId", "dbo.CQStatus");
            DropForeignKey("dbo.HeilPoes", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.HeilPoes", "PoOrderStatus_PoOrderStatusId", "dbo.PoOrderStatus");
            DropForeignKey("dbo.HeilPoes", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.HeilPoes", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.HeilPoes", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.HeilShips", new[] { "ShipPlanStatus_ShipPlanStatusId" });
            DropIndex("dbo.HeilShips", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.HeilShips", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.HeilShips", new[] { "Customer_CustomerId" });
            DropIndex("dbo.HeilShips", new[] { "CQStatus_CQStatusId" });
            DropIndex("dbo.HeilPoes", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.HeilPoes", new[] { "PoOrderStatus_PoOrderStatusId" });
            DropIndex("dbo.HeilPoes", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.HeilPoes", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.HeilPoes", new[] { "Customer_CustomerId" });
            DropTable("dbo.HeilShips");
            DropTable("dbo.HeilQohs");
            DropTable("dbo.HeilPoes");
        }
    }
}
