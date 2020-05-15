namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class txqohv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TxQohs", "CustomerId", c => c.Byte(nullable: false));
            AddColumn("dbo.TxQohs", "CustomerDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.TxQohs", "MlsDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.TxQohs", "ActivePartId", c => c.Byte(nullable: false));
            AddColumn("dbo.TxQohs", "PartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.TxQohs", "ActivePart_ActivePartId", c => c.Int());
            AddColumn("dbo.TxQohs", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.TxQohs", "CustomerDivision_CustomerDivisionId", c => c.Int());
            AddColumn("dbo.TxQohs", "MlsDivision_MlsDivisionId", c => c.Int());
            AddColumn("dbo.TxQohs", "PartType_PartTypeId", c => c.Int());
            CreateIndex("dbo.TxQohs", "ActivePart_ActivePartId");
            CreateIndex("dbo.TxQohs", "Customer_CustomerId");
            CreateIndex("dbo.TxQohs", "CustomerDivision_CustomerDivisionId");
            CreateIndex("dbo.TxQohs", "MlsDivision_MlsDivisionId");
            CreateIndex("dbo.TxQohs", "PartType_PartTypeId");
            AddForeignKey("dbo.TxQohs", "ActivePart_ActivePartId", "dbo.ActiveParts", "ActivePartId");
            AddForeignKey("dbo.TxQohs", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.TxQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId");
            AddForeignKey("dbo.TxQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions", "MlsDivisionId");
            AddForeignKey("dbo.TxQohs", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TxQohs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.TxQohs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.TxQohs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.TxQohs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.TxQohs", "ActivePart_ActivePartId", "dbo.ActiveParts");
            DropIndex("dbo.TxQohs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.TxQohs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.TxQohs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.TxQohs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.TxQohs", new[] { "ActivePart_ActivePartId" });
            DropColumn("dbo.TxQohs", "PartType_PartTypeId");
            DropColumn("dbo.TxQohs", "MlsDivision_MlsDivisionId");
            DropColumn("dbo.TxQohs", "CustomerDivision_CustomerDivisionId");
            DropColumn("dbo.TxQohs", "Customer_CustomerId");
            DropColumn("dbo.TxQohs", "ActivePart_ActivePartId");
            DropColumn("dbo.TxQohs", "PartTypeId");
            DropColumn("dbo.TxQohs", "ActivePartId");
            DropColumn("dbo.TxQohs", "MlsDivisionId");
            DropColumn("dbo.TxQohs", "CustomerDivisionId");
            DropColumn("dbo.TxQohs", "CustomerId");
        }
    }
}
