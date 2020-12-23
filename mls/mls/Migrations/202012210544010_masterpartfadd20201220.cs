namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masterpartfadd20201220 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileMasterPartFs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        MasterPartFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasterPartFs", t => t.MasterPartFId, cascadeDelete: true)
                .Index(t => t.MasterPartFId);
            
            CreateTable(
                "dbo.MasterPartFs",
                c => new
                    {
                        MasterPartFId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ActivePartId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        DocStatusId = c.Byte(nullable: false),
                        CustomerPn = c.String(nullable: false),
                        MlsPn = c.String(),
                        PartDescription = c.String(),
                        DrawingRev = c.String(),
                        BomRev = c.String(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        HtsCode = c.String(),
                        Notes = c.String(),
                        ActivePart_ActivePartId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        DocStatus_DocStatusId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.MasterPartFId)
                .ForeignKey("dbo.ActiveParts", t => t.ActivePart_ActivePartId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.DocStatus", t => t.DocStatus_DocStatusId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .Index(t => t.ActivePart_ActivePartId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.DocStatus_DocStatusId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PartType_PartTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MasterPartFs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.MasterPartFs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.FileMasterPartFs", "MasterPartFId", "dbo.MasterPartFs");
            DropForeignKey("dbo.MasterPartFs", "DocStatus_DocStatusId", "dbo.DocStatus");
            DropForeignKey("dbo.MasterPartFs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.MasterPartFs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MasterPartFs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropIndex("dbo.MasterPartFs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.MasterPartFs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.MasterPartFs", new[] { "DocStatus_DocStatusId" });
            DropIndex("dbo.MasterPartFs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.MasterPartFs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.MasterPartFs", new[] { "ActivePart_ActivePartId" });
            DropIndex("dbo.FileMasterPartFs", new[] { "MasterPartFId" });
            DropTable("dbo.MasterPartFs");
            DropTable("dbo.FileMasterPartFs");
        }
    }
}
