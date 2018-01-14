namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncrchina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NcrChinas",
                c => new
                    {
                        NcrChinaId = c.Int(nullable: false, identity: true),
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
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        Disposition_DispositionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        NcrType_NcrTypeId = c.Int(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.NcrChinaId)
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
            
            AddColumn("dbo.Customers", "NcrChinaId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "NcrChina_NcrChinaId", c => c.Int());
            AddColumn("dbo.Customers", "NcrChinas_NcrChinaId", c => c.Int());
            AddColumn("dbo.CustomerDivisions", "NcrChinaId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerDivisions", "NcrChinas_NcrChinaId", c => c.Int());
            AddColumn("dbo.CustomerDivisions", "NcrChina_NcrChinaId", c => c.Int());
            AddColumn("dbo.MlsDivisions", "NcrChinaId", c => c.Int(nullable: false));
            AddColumn("dbo.MlsDivisions", "NcrChinas_NcrChinaId", c => c.Int());
            AddColumn("dbo.MlsDivisions", "NcrChina_NcrChinaId", c => c.Int());
            AddColumn("dbo.Dispositions", "NcrChinaId", c => c.Int(nullable: false));
            AddColumn("dbo.Dispositions", "NcrChinas_NcrChinaId", c => c.Int());
            AddColumn("dbo.Dispositions", "NcrChina_NcrChinaId", c => c.Int());
            AddColumn("dbo.NcrTypes", "NcrChinaId", c => c.Int(nullable: false));
            AddColumn("dbo.NcrTypes", "NcrChinas_NcrChinaId", c => c.Int());
            AddColumn("dbo.NcrTypes", "NcrChina_NcrChinaId", c => c.Int());
            AddColumn("dbo.Status", "NcrChina_NcrChinaId", c => c.Int());
            CreateIndex("dbo.Customers", "NcrChina_NcrChinaId");
            CreateIndex("dbo.Customers", "NcrChinas_NcrChinaId");
            CreateIndex("dbo.CustomerDivisions", "NcrChinas_NcrChinaId");
            CreateIndex("dbo.CustomerDivisions", "NcrChina_NcrChinaId");
            CreateIndex("dbo.Dispositions", "NcrChinas_NcrChinaId");
            CreateIndex("dbo.Dispositions", "NcrChina_NcrChinaId");
            CreateIndex("dbo.MlsDivisions", "NcrChinas_NcrChinaId");
            CreateIndex("dbo.MlsDivisions", "NcrChina_NcrChinaId");
            CreateIndex("dbo.NcrTypes", "NcrChinas_NcrChinaId");
            CreateIndex("dbo.NcrTypes", "NcrChina_NcrChinaId");
            CreateIndex("dbo.Status", "NcrChina_NcrChinaId");
            AddForeignKey("dbo.CustomerDivisions", "NcrChinas_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.CustomerDivisions", "NcrChina_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.Customers", "NcrChina_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.Dispositions", "NcrChinas_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.Dispositions", "NcrChina_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.MlsDivisions", "NcrChinas_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.MlsDivisions", "NcrChina_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.NcrTypes", "NcrChinas_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.NcrTypes", "NcrChina_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.Status", "NcrChina_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
            AddForeignKey("dbo.Customers", "NcrChinas_NcrChinaId", "dbo.NcrChinas", "NcrChinaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "NcrChinas_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.Status", "NcrChina_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.NcrChinas", "Status_StatusId", "dbo.Status");
            DropForeignKey("dbo.NcrTypes", "NcrChina_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.NcrChinas", "NcrType_NcrTypeId", "dbo.NcrTypes");
            DropForeignKey("dbo.NcrTypes", "NcrChinas_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.MlsDivisions", "NcrChina_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.NcrChinas", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.MlsDivisions", "NcrChinas_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.Dispositions", "NcrChina_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.NcrChinas", "Disposition_DispositionId", "dbo.Dispositions");
            DropForeignKey("dbo.Dispositions", "NcrChinas_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.Customers", "NcrChina_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.CustomerDivisions", "NcrChina_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.NcrChinas", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.CustomerDivisions", "NcrChinas_NcrChinaId", "dbo.NcrChinas");
            DropForeignKey("dbo.NcrChinas", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Status", new[] { "NcrChina_NcrChinaId" });
            DropIndex("dbo.NcrTypes", new[] { "NcrChina_NcrChinaId" });
            DropIndex("dbo.NcrTypes", new[] { "NcrChinas_NcrChinaId" });
            DropIndex("dbo.MlsDivisions", new[] { "NcrChina_NcrChinaId" });
            DropIndex("dbo.MlsDivisions", new[] { "NcrChinas_NcrChinaId" });
            DropIndex("dbo.Dispositions", new[] { "NcrChina_NcrChinaId" });
            DropIndex("dbo.Dispositions", new[] { "NcrChinas_NcrChinaId" });
            DropIndex("dbo.CustomerDivisions", new[] { "NcrChina_NcrChinaId" });
            DropIndex("dbo.CustomerDivisions", new[] { "NcrChinas_NcrChinaId" });
            DropIndex("dbo.NcrChinas", new[] { "Status_StatusId" });
            DropIndex("dbo.NcrChinas", new[] { "NcrType_NcrTypeId" });
            DropIndex("dbo.NcrChinas", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.NcrChinas", new[] { "Disposition_DispositionId" });
            DropIndex("dbo.NcrChinas", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.NcrChinas", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Customers", new[] { "NcrChinas_NcrChinaId" });
            DropIndex("dbo.Customers", new[] { "NcrChina_NcrChinaId" });
            DropColumn("dbo.Status", "NcrChina_NcrChinaId");
            DropColumn("dbo.NcrTypes", "NcrChina_NcrChinaId");
            DropColumn("dbo.NcrTypes", "NcrChinas_NcrChinaId");
            DropColumn("dbo.NcrTypes", "NcrChinaId");
            DropColumn("dbo.Dispositions", "NcrChina_NcrChinaId");
            DropColumn("dbo.Dispositions", "NcrChinas_NcrChinaId");
            DropColumn("dbo.Dispositions", "NcrChinaId");
            DropColumn("dbo.MlsDivisions", "NcrChina_NcrChinaId");
            DropColumn("dbo.MlsDivisions", "NcrChinas_NcrChinaId");
            DropColumn("dbo.MlsDivisions", "NcrChinaId");
            DropColumn("dbo.CustomerDivisions", "NcrChina_NcrChinaId");
            DropColumn("dbo.CustomerDivisions", "NcrChinas_NcrChinaId");
            DropColumn("dbo.CustomerDivisions", "NcrChinaId");
            DropColumn("dbo.Customers", "NcrChinas_NcrChinaId");
            DropColumn("dbo.Customers", "NcrChina_NcrChinaId");
            DropColumn("dbo.Customers", "NcrChinaId");
            DropTable("dbo.NcrChinas");
        }
    }
}
