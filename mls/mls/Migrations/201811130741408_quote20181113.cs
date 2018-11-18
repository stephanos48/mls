namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quote20181113 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotes", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.CustomerQuotes", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerQuotes", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropIndex("dbo.Quotes", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.CustomerQuotes", new[] { "Customer_CustomerId" });
            DropIndex("dbo.CustomerQuotes", new[] { "CustomerDivision_CustomerDivisionId" });
            RenameColumn(table: "dbo.Quotes", name: "Supplier_SupplierId", newName: "SupplierId");
            RenameColumn(table: "dbo.CustomerQuotes", name: "Customer_CustomerId", newName: "CustomerId");
            RenameColumn(table: "dbo.CustomerQuotes", name: "CustomerDivision_CustomerDivisionId", newName: "CustomerDivisionId");
            AlterColumn("dbo.Quotes", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerQuotes", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerQuotes", "CustomerDivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quotes", "SupplierId");
            CreateIndex("dbo.CustomerQuotes", "CustomerId");
            CreateIndex("dbo.CustomerQuotes", "CustomerDivisionId");
            AddForeignKey("dbo.Quotes", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
            AddForeignKey("dbo.CustomerQuotes", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.CustomerQuotes", "CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerQuotes", "CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.CustomerQuotes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Quotes", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.CustomerQuotes", new[] { "CustomerDivisionId" });
            DropIndex("dbo.CustomerQuotes", new[] { "CustomerId" });
            DropIndex("dbo.Quotes", new[] { "SupplierId" });
            AlterColumn("dbo.CustomerQuotes", "CustomerDivisionId", c => c.Int());
            AlterColumn("dbo.CustomerQuotes", "CustomerId", c => c.Int());
            AlterColumn("dbo.Quotes", "SupplierId", c => c.Int());
            RenameColumn(table: "dbo.CustomerQuotes", name: "CustomerDivisionId", newName: "CustomerDivision_CustomerDivisionId");
            RenameColumn(table: "dbo.CustomerQuotes", name: "CustomerId", newName: "Customer_CustomerId");
            RenameColumn(table: "dbo.Quotes", name: "SupplierId", newName: "Supplier_SupplierId");
            CreateIndex("dbo.CustomerQuotes", "CustomerDivision_CustomerDivisionId");
            CreateIndex("dbo.CustomerQuotes", "Customer_CustomerId");
            CreateIndex("dbo.Quotes", "Supplier_SupplierId");
            AddForeignKey("dbo.CustomerQuotes", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId");
            AddForeignKey("dbo.CustomerQuotes", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Quotes", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
    }
}
