namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vtadd2020122 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VtCycleCounts",
                c => new
                    {
                        VtCycleCountId = c.Int(nullable: false, identity: true),
                        CycleCountDateTime = c.DateTime(),
                        CustomerPn = c.String(),
                        PortalQty = c.Int(nullable: false),
                        ActualQty = c.Int(nullable: false),
                        LocationsCounted = c.String(),
                        CountedBy = c.String(),
                        AuditedBy = c.String(),
                        CountOff = c.String(),
                        CorrectedBy = c.String(),
                        CorrectedDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.VtCycleCountId);
            
            CreateTable(
                "dbo.VtPfeps",
                c => new
                    {
                        VtPfepId = c.Int(nullable: false, identity: true),
                        CustomerPn = c.String(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        QohVt = c.Int(),
                        NcrQtyVt = c.Int(),
                        PfepEsg = c.Int(),
                        PfepVt = c.Int(),
                        MinVt = c.Int(),
                        MaxVt = c.Int(),
                        KbQty = c.Int(),
                        PartType_PartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.VtPfepId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .Index(t => t.PartType_PartTypeId);
            
            CreateTable(
                "dbo.VtShipPlans",
                c => new
                    {
                        VtShipPlanId = c.Int(nullable: false, identity: true),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        CustomerOrderNo = c.String(nullable: false),
                        CustomerOrderLine = c.String(),
                        SoNumber = c.String(),
                        CustomerPn = c.String(),
                        PartDescription = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ShipQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ShipDateTime = c.DateTime(),
                        ShipPlanStatusId = c.Byte(nullable: false),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        ShipToAddress = c.String(),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        ShipPlanStatus_ShipPlanStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.VtShipPlanId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.ShipPlanStatus", t => t.ShipPlanStatus_ShipPlanStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.ShipPlanStatus_ShipPlanStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VtShipPlans", "ShipPlanStatus_ShipPlanStatusId", "dbo.ShipPlanStatus");
            DropForeignKey("dbo.VtShipPlans", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.VtShipPlans", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.VtPfeps", "PartType_PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.VtShipPlans", new[] { "ShipPlanStatus_ShipPlanStatusId" });
            DropIndex("dbo.VtShipPlans", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.VtShipPlans", new[] { "Customer_CustomerId" });
            DropIndex("dbo.VtPfeps", new[] { "PartType_PartTypeId" });
            DropTable("dbo.VtShipPlans");
            DropTable("dbo.VtPfeps");
            DropTable("dbo.VtCycleCounts");
        }
    }
}
