namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipout2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipOut2Detail",
                c => new
                    {
                        ShipOut2DetailId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        Sn = c.String(),
                        Quantity = c.Int(nullable: false),
                        ManifestNo = c.String(),
                        PoNumber = c.String(),
                        SoNumber = c.String(),
                        PalletNo = c.String(),
                        Notes = c.String(),
                        ShipOut2Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipOut2DetailId)
                .ForeignKey("dbo.ShipOut2", t => t.ShipOut2Id, cascadeDelete: true)
                .Index(t => t.ShipOut2Id);
            
            CreateTable(
                "dbo.ShipOut2",
                c => new
                    {
                        ShipOut2Id = c.Int(nullable: false, identity: true),
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
                        ShipTerms = c.String(),
                        ShipCity = c.String(),
                        ShipState = c.String(),
                        ShipZip = c.String(),
                        ShipDescription = c.String(),
                        ShipWeight = c.String(),
                        ShipDate = c.DateTime(),
                        ETADate = c.DateTime(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        FpaymentMethod_FPaymentMethodId = c.Int(),
                        FreightType_FreightTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ShipOut2Id)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.FPaymentMethods", t => t.FpaymentMethod_FPaymentMethodId)
                .ForeignKey("dbo.FreightTypes", t => t.FreightType_FreightTypeId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.FpaymentMethod_FPaymentMethodId)
                .Index(t => t.FreightType_FreightTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipOut2Detail", "ShipOut2Id", "dbo.ShipOut2");
            DropForeignKey("dbo.ShipOut2", "FreightType_FreightTypeId", "dbo.FreightTypes");
            DropForeignKey("dbo.ShipOut2", "FpaymentMethod_FPaymentMethodId", "dbo.FPaymentMethods");
            DropForeignKey("dbo.ShipOut2", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ShipOut2", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.ShipOut2", new[] { "FreightType_FreightTypeId" });
            DropIndex("dbo.ShipOut2", new[] { "FpaymentMethod_FPaymentMethodId" });
            DropIndex("dbo.ShipOut2", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ShipOut2", new[] { "Customer_CustomerId" });
            DropIndex("dbo.ShipOut2Detail", new[] { "ShipOut2Id" });
            DropTable("dbo.ShipOut2");
            DropTable("dbo.ShipOut2Detail");
        }
    }
}
