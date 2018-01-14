namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipinv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipIns",
                c => new
                    {
                        ShipInId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        Destination = c.String(),
                        ContainerId = c.String(),
                        ContainerUh = c.String(),
                        BOL = c.String(),
                        AMS = c.String(),
                        CO = c.String(),
                        Invoice = c.String(),
                        Seal = c.String(),
                        Port = c.String(),
                        Pallet = c.String(),
                        Pn = c.String(),
                        UhPn = c.String(),
                        Shipdate = c.DateTime(),
                        Etadate = c.DateTime(),
                        Qty = c.Int(nullable: false),
                        Hub = c.String(),
                        Hubeta = c.DateTime(),
                        Receiptdate = c.DateTime(),
                        Receivedby = c.String(),
                        Qtyconfirmed = c.String(),
                        ShipInStatusId = c.Byte(nullable: false),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        ShipInStatus_ShipInStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ShipInId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.ShipInStatus", t => t.ShipInStatus_ShipInStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.ShipInStatus_ShipInStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipIns", "ShipInStatus_ShipInStatusId", "dbo.ShipInStatus");
            DropForeignKey("dbo.ShipIns", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ShipIns", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.ShipIns", new[] { "ShipInStatus_ShipInStatusId" });
            DropIndex("dbo.ShipIns", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ShipIns", new[] { "Customer_CustomerId" });
            DropTable("dbo.ShipIns");
        }
    }
}
