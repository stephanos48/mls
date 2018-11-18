namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerquote20181112 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        QuoteId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        QuoteDate = c.DateTime(),
                        QuotedPrice = c.String(),
                        PriceBreak = c.String(),
                        Tariff = c.String(),
                        Terms = c.String(),
                        QuoteBy = c.String(),
                        Notes = c.String(),
                        Supplier_SupplierId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.QuoteId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Supplier_SupplierId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.CustomerQuotes",
                c => new
                    {
                        CustomerQuoteId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        QuoteDate = c.DateTime(),
                        QuotedPrice = c.String(),
                        PriceBreak = c.String(),
                        Tariff = c.String(),
                        Terms = c.String(),
                        QuoteBy = c.String(),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerQuoteId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId);
            
            AddColumn("dbo.Checklists", "ChecklistAction", c => c.String());
            AddColumn("dbo.Checklists", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Checklists", "Department_DepartmentId");
            AddForeignKey("dbo.Checklists", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Checklists", "ChecklistTypeId");
            DropColumn("dbo.Checklists", "EmployeeId");
            DropColumn("dbo.Checklists", "Action");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checklists", "Action", c => c.String());
            AddColumn("dbo.Checklists", "EmployeeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Checklists", "ChecklistTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.CustomerQuotes", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.CustomerQuotes", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Checklists", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Quotes", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Quotes", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.Quotes", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.CustomerQuotes", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.CustomerQuotes", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Checklists", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Quotes", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Quotes", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.Quotes", new[] { "Supplier_SupplierId" });
            DropColumn("dbo.Checklists", "Department_DepartmentId");
            DropColumn("dbo.Checklists", "ChecklistAction");
            DropTable("dbo.CustomerQuotes");
            DropTable("dbo.Quotes");
        }
    }
}
