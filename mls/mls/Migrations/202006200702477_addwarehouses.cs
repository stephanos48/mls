namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwarehouses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtQohs",
                c => new
                    {
                        ExtQohId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ActivePartId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        Pn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        Qoh = c.Int(nullable: false),
                        Location = c.String(),
                        Notes = c.String(),
                        ActivePart_ActivePartId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ExtQohId)
                .ForeignKey("dbo.ActiveParts", t => t.ActivePart_ActivePartId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .Index(t => t.ActivePart_ActivePartId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PartType_PartTypeId);
            
            CreateTable(
                "dbo.VtQohs",
                c => new
                    {
                        VtQohId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ActivePartId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        Pn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        Qoh = c.Int(nullable: false),
                        Location = c.String(),
                        Notes = c.String(),
                        ActivePart_ActivePartId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.VtQohId)
                .ForeignKey("dbo.ActiveParts", t => t.ActivePart_ActivePartId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .Index(t => t.ActivePart_ActivePartId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PartType_PartTypeId);
            
            AddColumn("dbo.TxQohLogs", "Location", c => c.String());
            AddColumn("dbo.TxQohs", "Location", c => c.String());
            DropColumn("dbo.TxQohLogs", "NcrQty");
            DropColumn("dbo.TxQohs", "NcrQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TxQohs", "NcrQty", c => c.Int(nullable: false));
            AddColumn("dbo.TxQohLogs", "NcrQty", c => c.Int(nullable: false));
            DropForeignKey("dbo.VtQohs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.VtQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.VtQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.VtQohs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.VtQohs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropForeignKey("dbo.ExtQohs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.ExtQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.ExtQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ExtQohs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ExtQohs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropIndex("dbo.VtQohs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.VtQohs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.VtQohs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.VtQohs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.VtQohs", new[] { "ActivePart_ActivePartId" });
            DropIndex("dbo.ExtQohs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.ExtQohs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.ExtQohs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ExtQohs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.ExtQohs", new[] { "ActivePart_ActivePartId" });
            DropColumn("dbo.TxQohs", "Location");
            DropColumn("dbo.TxQohLogs", "Location");
            DropTable("dbo.VtQohs");
            DropTable("dbo.ExtQohs");
        }
    }
}
