namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpoplanlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoPlanLogs",
                c => new
                    {
                        PoPlanLogId = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        EventDateTime = c.DateTime(),
                        EventType = c.String(),
                        PoPlanId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.PoPlanLogId)
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
                "dbo.TxQohLogs",
                c => new
                    {
                        TxQohLogId = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        EventDateTime = c.DateTime(),
                        EventType = c.String(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ActivePartId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        Pn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        Qoh = c.Int(nullable: false),
                        NcrQty = c.Int(nullable: false),
                        Notes = c.String(),
                        ActivePart_ActivePartId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.TxQohLogId)
                .ForeignKey("dbo.ActiveParts", t => t.ActivePart_ActivePartId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .Index(t => t.ActivePart_ActivePartId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PartType_PartTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TxQohLogs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.TxQohLogs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.TxQohLogs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.TxQohLogs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.TxQohLogs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropForeignKey("dbo.PoPlanLogs", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PoPlanLogs", "PoOrderStatus_PoOrderStatusId", "dbo.PoOrderStatus");
            DropForeignKey("dbo.PoPlanLogs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.PoPlanLogs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.PoPlanLogs", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.TxQohLogs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.TxQohLogs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.TxQohLogs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.TxQohLogs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.TxQohLogs", new[] { "ActivePart_ActivePartId" });
            DropIndex("dbo.PoPlanLogs", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.PoPlanLogs", new[] { "PoOrderStatus_PoOrderStatusId" });
            DropIndex("dbo.PoPlanLogs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.PoPlanLogs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.PoPlanLogs", new[] { "Customer_CustomerId" });
            DropTable("dbo.TxQohLogs");
            DropTable("dbo.PoPlanLogs");
        }
    }
}
