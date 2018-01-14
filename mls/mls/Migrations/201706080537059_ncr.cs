namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispositions",
                c => new
                    {
                        DispositionId = c.Int(nullable: false, identity: true),
                        DispositionType = c.String(),
                    })
                .PrimaryKey(t => t.DispositionId);
            
            CreateTable(
                "dbo.NCRs",
                c => new
                    {
                        NcrId = c.Int(nullable: false, identity: true),
                        NcrNumber = c.String(nullable: false),
                        IssueDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        PartSupplier = c.String(),
                        PartNumber = c.String(),
                        PartDescription = c.String(),
                        SerialNumber = c.String(),
                        PartCost = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        DefectDescription = c.String(),
                        DefectCode = c.String(),
                        MlsDivisionId = c.Byte(nullable: false),
                        DispositionId = c.Byte(nullable: false),
                        DispositionDateTime = c.DateTime(),
                        DispositionedBy = c.String(),
                        StatusId = c.Byte(nullable: false),
                        ReworkNumber = c.String(),
                        ReworkCompletedBy = c.String(),
                        ReworkHrs = c.Decimal(precision: 18, scale: 2),
                        ReworkPartsUsed = c.String(),
                        ReworkPartsScrapped = c.String(),
                        ReworkQty = c.Int(),
                        ReworkStatus = c.String(),
                        ReworkNotes = c.String(),
                        ScrapNumber = c.String(),
                        ScrapQty = c.Int(),
                        ScrapApprovedBy = c.String(),
                        ScrapApprovalDate = c.String(),
                        ScrappedBy = c.String(),
                        ScrapDate = c.DateTime(),
                        ScrapNotes = c.String(),
                        ScrapStatus = c.String(),
                        RtvNumber = c.String(),
                        ShipperNumber = c.String(),
                        RgNumber = c.String(),
                        ShipDate = c.DateTime(),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        ShipTo = c.String(),
                        RtvNotes = c.String(),
                        RtvStatus = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        Disposition_DispositionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.NcrId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.Dispositions", t => t.Disposition_DispositionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.Status", t => t.Status_StatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.Disposition_DispositionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.Status_StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NCRs", "Status_StatusId", "dbo.Status");
            DropForeignKey("dbo.NCRs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.NCRs", "Disposition_DispositionId", "dbo.Dispositions");
            DropForeignKey("dbo.NCRs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.NCRs", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.NCRs", new[] { "Status_StatusId" });
            DropIndex("dbo.NCRs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.NCRs", new[] { "Disposition_DispositionId" });
            DropIndex("dbo.NCRs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.NCRs", new[] { "Customer_CustomerId" });
            DropTable("dbo.Status");
            DropTable("dbo.NCRs");
            DropTable("dbo.Dispositions");
        }
    }
}
