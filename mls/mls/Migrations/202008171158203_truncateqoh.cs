namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class truncateqoh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtQohs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropForeignKey("dbo.ExtQohs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ExtQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.ExtQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.ExtQohs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.VtQohs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropForeignKey("dbo.VtQohs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.VtQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.VtQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.VtQohs", "PartType_PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.ExtQohs", new[] { "ActivePart_ActivePartId" });
            DropIndex("dbo.ExtQohs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.ExtQohs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.ExtQohs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.ExtQohs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.VtQohs", new[] { "ActivePart_ActivePartId" });
            DropIndex("dbo.VtQohs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.VtQohs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.VtQohs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.VtQohs", new[] { "PartType_PartTypeId" });
            DropColumn("dbo.ExtQohs", "CustomerId");
            DropColumn("dbo.ExtQohs", "CustomerDivisionId");
            DropColumn("dbo.ExtQohs", "MlsDivisionId");
            DropColumn("dbo.ExtQohs", "ActivePartId");
            DropColumn("dbo.ExtQohs", "PartTypeId");
            DropColumn("dbo.ExtQohs", "UhPn");
            DropColumn("dbo.ExtQohs", "ActivePart_ActivePartId");
            DropColumn("dbo.ExtQohs", "Customer_CustomerId");
            DropColumn("dbo.ExtQohs", "CustomerDivision_CustomerDivisionId");
            DropColumn("dbo.ExtQohs", "MlsDivision_MlsDivisionId");
            DropColumn("dbo.ExtQohs", "PartType_PartTypeId");
            DropColumn("dbo.VtQohs", "CustomerId");
            DropColumn("dbo.VtQohs", "CustomerDivisionId");
            DropColumn("dbo.VtQohs", "MlsDivisionId");
            DropColumn("dbo.VtQohs", "ActivePartId");
            DropColumn("dbo.VtQohs", "PartTypeId");
            DropColumn("dbo.VtQohs", "UhPn");
            DropColumn("dbo.VtQohs", "ActivePart_ActivePartId");
            DropColumn("dbo.VtQohs", "Customer_CustomerId");
            DropColumn("dbo.VtQohs", "CustomerDivision_CustomerDivisionId");
            DropColumn("dbo.VtQohs", "MlsDivision_MlsDivisionId");
            DropColumn("dbo.VtQohs", "PartType_PartTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VtQohs", "PartType_PartTypeId", c => c.Int());
            AddColumn("dbo.VtQohs", "MlsDivision_MlsDivisionId", c => c.Int());
            AddColumn("dbo.VtQohs", "CustomerDivision_CustomerDivisionId", c => c.Int());
            AddColumn("dbo.VtQohs", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.VtQohs", "ActivePart_ActivePartId", c => c.Int());
            AddColumn("dbo.VtQohs", "UhPn", c => c.String());
            AddColumn("dbo.VtQohs", "PartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.VtQohs", "ActivePartId", c => c.Byte(nullable: false));
            AddColumn("dbo.VtQohs", "MlsDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.VtQohs", "CustomerDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.VtQohs", "CustomerId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExtQohs", "PartType_PartTypeId", c => c.Int());
            AddColumn("dbo.ExtQohs", "MlsDivision_MlsDivisionId", c => c.Int());
            AddColumn("dbo.ExtQohs", "CustomerDivision_CustomerDivisionId", c => c.Int());
            AddColumn("dbo.ExtQohs", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.ExtQohs", "ActivePart_ActivePartId", c => c.Int());
            AddColumn("dbo.ExtQohs", "UhPn", c => c.String());
            AddColumn("dbo.ExtQohs", "PartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExtQohs", "ActivePartId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExtQohs", "MlsDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExtQohs", "CustomerDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExtQohs", "CustomerId", c => c.Byte(nullable: false));
            CreateIndex("dbo.VtQohs", "PartType_PartTypeId");
            CreateIndex("dbo.VtQohs", "MlsDivision_MlsDivisionId");
            CreateIndex("dbo.VtQohs", "CustomerDivision_CustomerDivisionId");
            CreateIndex("dbo.VtQohs", "Customer_CustomerId");
            CreateIndex("dbo.VtQohs", "ActivePart_ActivePartId");
            CreateIndex("dbo.ExtQohs", "PartType_PartTypeId");
            CreateIndex("dbo.ExtQohs", "MlsDivision_MlsDivisionId");
            CreateIndex("dbo.ExtQohs", "CustomerDivision_CustomerDivisionId");
            CreateIndex("dbo.ExtQohs", "Customer_CustomerId");
            CreateIndex("dbo.ExtQohs", "ActivePart_ActivePartId");
            AddForeignKey("dbo.VtQohs", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
            AddForeignKey("dbo.VtQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions", "MlsDivisionId");
            AddForeignKey("dbo.VtQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId");
            AddForeignKey("dbo.VtQohs", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.VtQohs", "ActivePart_ActivePartId", "dbo.ActiveParts", "ActivePartId");
            AddForeignKey("dbo.ExtQohs", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
            AddForeignKey("dbo.ExtQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions", "MlsDivisionId");
            AddForeignKey("dbo.ExtQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId");
            AddForeignKey("dbo.ExtQohs", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.ExtQohs", "ActivePart_ActivePartId", "dbo.ActiveParts", "ActivePartId");
        }
    }
}
