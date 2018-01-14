namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipOuts",
                c => new
                    {
                        ShipOutId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        FreightTypeId = c.Byte(nullable: false),
                        FPaymentMethodId = c.Byte(nullable: false),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        Destination = c.String(),
                        Quote = c.String(),
                        SoldTo = c.String(),
                        ShipTo = c.String(),
                        ShipCity = c.String(),
                        ShipState = c.String(),
                        ShipZip = c.String(),
                        ShipDescription = c.String(),
                        ShipWeight = c.String(),
                        ManifestNo = c.String(),
                        PoNumber = c.String(),
                        SoNumber = c.String(),
                        PalletNo = c.String(),
                        Pn = c.String(),
                        Sn = c.String(),
                        ShipDate = c.String(),
                        Quantity = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        FpaymentMethod_FPaymentMethodId = c.Int(),
                        FreightType_FreightTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ShipOutId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.FPaymentMethods", t => t.FpaymentMethod_FPaymentMethodId)
                .ForeignKey("dbo.FreightTypes", t => t.FreightType_FreightTypeId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.FpaymentMethod_FPaymentMethodId)
                .Index(t => t.FreightType_FreightTypeId);
            
            CreateTable(
                "dbo.FPaymentMethods",
                c => new
                    {
                        FPaymentMethodId = c.Int(nullable: false, identity: true),
                        FPaymentMethodName = c.String(),
                    })
                .PrimaryKey(t => t.FPaymentMethodId);
            
            CreateTable(
                "dbo.FreightTypes",
                c => new
                    {
                        FreightTypeId = c.Int(nullable: false, identity: true),
                        FreightTypeName = c.String(),
                    })
                .PrimaryKey(t => t.FreightTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipOuts", "FreightType_FreightTypeId", "dbo.FreightTypes");
            DropForeignKey("dbo.ShipOuts", "FpaymentMethod_FPaymentMethodId", "dbo.FPaymentMethods");
            DropForeignKey("dbo.ShipOuts", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ShipOuts", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.ShipOuts", new[] { "FreightType_FreightTypeId" });
            DropIndex("dbo.ShipOuts", new[] { "FpaymentMethod_FPaymentMethodId" });
            DropIndex("dbo.ShipOuts", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ShipOuts", new[] { "Customer_CustomerId" });
            DropTable("dbo.FreightTypes");
            DropTable("dbo.FPaymentMethods");
            DropTable("dbo.ShipOuts");
        }
    }
}
