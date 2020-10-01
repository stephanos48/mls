namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipplanfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipFileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        ShipPLanFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShipPlanFs", t => t.ShipPLanFId, cascadeDelete: true)
                .Index(t => t.ShipPLanFId);
            
            CreateTable(
                "dbo.ShipPlanFs",
                c => new
                    {
                        ShipPlanFId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.ShipPlanFId)
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
            DropForeignKey("dbo.ShipPlanFs", "ShipPlanStatus_ShipPlanStatusId", "dbo.ShipPlanStatus");
            DropForeignKey("dbo.ShipFileDetails", "ShipPLanFId", "dbo.ShipPlanFs");
            DropForeignKey("dbo.ShipPlanFs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.ShipPlanFs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ShipPlanFs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ShipPlanFs", "CQStatus_CQStatusId", "dbo.CQStatus");
            DropIndex("dbo.ShipPlanFs", new[] { "ShipPlanStatus_ShipPlanStatusId" });
            DropIndex("dbo.ShipPlanFs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.ShipPlanFs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ShipPlanFs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.ShipPlanFs", new[] { "CQStatus_CQStatusId" });
            DropIndex("dbo.ShipFileDetails", new[] { "ShipPLanFId" });
            DropTable("dbo.ShipPlanFs");
            DropTable("dbo.ShipFileDetails");
        }
    }
}
