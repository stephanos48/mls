namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addncrf20201220 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileNcrFDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        NcrFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NcrFs", t => t.NcrFId, cascadeDelete: true)
                .Index(t => t.NcrFId);
            
            CreateTable(
                "dbo.NcrFs",
                c => new
                    {
                        NcrFId = c.Int(nullable: false, identity: true),
                        NcrNumber = c.String(nullable: false),
                        IssueDateTime = c.DateTime(),
                        NcrTypeId = c.Byte(nullable: false),
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
                        DispositionId = c.Byte(),
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
                        ReworkCost = c.String(),
                        ScrapCost = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        Disposition_DispositionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        NcrType_NcrTypeId = c.Int(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.NcrFId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.Dispositions", t => t.Disposition_DispositionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.NcrTypes", t => t.NcrType_NcrTypeId)
                .ForeignKey("dbo.Status", t => t.Status_StatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.Disposition_DispositionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.NcrType_NcrTypeId)
                .Index(t => t.Status_StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NcrFs", "Status_StatusId", "dbo.Status");
            DropForeignKey("dbo.NcrFs", "NcrType_NcrTypeId", "dbo.NcrTypes");
            DropForeignKey("dbo.NcrFs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.FileNcrFDetails", "NcrFId", "dbo.NcrFs");
            DropForeignKey("dbo.NcrFs", "Disposition_DispositionId", "dbo.Dispositions");
            DropForeignKey("dbo.NcrFs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.NcrFs", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.NcrFs", new[] { "Status_StatusId" });
            DropIndex("dbo.NcrFs", new[] { "NcrType_NcrTypeId" });
            DropIndex("dbo.NcrFs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.NcrFs", new[] { "Disposition_DispositionId" });
            DropIndex("dbo.NcrFs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.NcrFs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.FileNcrFDetails", new[] { "NcrFId" });
            DropTable("dbo.NcrFs");
            DropTable("dbo.FileNcrFDetails");
        }
    }
}
