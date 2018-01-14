namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masterpart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActiveParts",
                c => new
                    {
                        ActivePartId = c.Int(nullable: false, identity: true),
                        ActivePartName = c.String(),
                    })
                .PrimaryKey(t => t.ActivePartId);
            
            CreateTable(
                "dbo.MasterPartLists",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ActivePartId = c.Byte(nullable: false),
                        PartType = c.String(),
                        CustomerPn = c.String(nullable: false),
                        MlsPn = c.String(),
                        PartDescription = c.String(),
                        PartPrice = c.Decimal(precision: 18, scale: 2),
                        PartCost = c.Decimal(precision: 18, scale: 2),
                        Weight = c.Int(nullable: false),
                        StdPack = c.Int(nullable: false),
                        Notes = c.String(),
                        ActivePart_ActivePartId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.ActiveParts", t => t.ActivePart_ActivePartId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.ActivePart_ActivePartId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MasterPartLists", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.MasterPartLists", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.MasterPartLists", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MasterPartLists", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropIndex("dbo.MasterPartLists", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.MasterPartLists", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.MasterPartLists", new[] { "Customer_CustomerId" });
            DropIndex("dbo.MasterPartLists", new[] { "ActivePart_ActivePartId" });
            DropTable("dbo.MasterPartLists");
            DropTable("dbo.ActiveParts");
        }
    }
}
