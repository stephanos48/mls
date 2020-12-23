namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proddevelop20201212 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileProdDevelops",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        ProdDevelopmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProdDevelopments", t => t.ProdDevelopmentId, cascadeDelete: true)
                .Index(t => t.ProdDevelopmentId);
            
            CreateTable(
                "dbo.ProdDevelopments",
                c => new
                    {
                        ProdDevelopmentId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        ReverseLocation = c.String(),
                        ReceiptDateTime = c.DateTime(),
                        IncCarrier = c.String(),
                        IncTrackingInfo = c.String(),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        SerialNo = c.String(),
                        ReceiptQty = c.Int(nullable: false),
                        ProdDevelopStatusId = c.Byte(nullable: false),
                        ShipDateTime = c.DateTime(),
                        ShipCarrier = c.String(),
                        ShipTrackingInfo = c.String(),
                        ShipToLocation = c.String(),
                        RoughDesignBomCompletionDateTime = c.DateTime(),
                        QuoteCompletionDateTime = c.DateTime(),
                        CustomerPoDateTime = c.DateTime(),
                        FinalDesignCompletionDateTime = c.DateTime(),
                        CustomerSignOffDateTime = c.DateTime(),
                        PrototypeCompletionDateTime = c.DateTime(),
                        LabTestCompletionDateTime = c.DateTime(),
                        CustomerTestCompletionDateTime = c.DateTime(),
                        FieldTrialCompletionDateTime = c.DateTime(),
                        ApprovedForProductionDateTime = c.DateTime(),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        ProdDevelopStatus_ProdDevelopStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdDevelopmentId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.ProdDevelopStatus", t => t.ProdDevelopStatus_ProdDevelopStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.ProdDevelopStatus_ProdDevelopStatusId);
            
            CreateTable(
                "dbo.ProdDevelopStatus",
                c => new
                    {
                        ProdDevelopStatusId = c.Int(nullable: false, identity: true),
                        ProdDevelopStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ProdDevelopStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdDevelopments", "ProdDevelopStatus_ProdDevelopStatusId", "dbo.ProdDevelopStatus");
            DropForeignKey("dbo.FileProdDevelops", "ProdDevelopmentId", "dbo.ProdDevelopments");
            DropForeignKey("dbo.ProdDevelopments", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.ProdDevelopments", new[] { "ProdDevelopStatus_ProdDevelopStatusId" });
            DropIndex("dbo.ProdDevelopments", new[] { "Customer_CustomerId" });
            DropIndex("dbo.FileProdDevelops", new[] { "ProdDevelopmentId" });
            DropTable("dbo.ProdDevelopStatus");
            DropTable("dbo.ProdDevelopments");
            DropTable("dbo.FileProdDevelops");
        }
    }
}
