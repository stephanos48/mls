namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poplan20190802 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoPlans",
                c => new
                    {
                        PoPlanId = c.Int(nullable: false, identity: true),
                        PoNumber = c.String(),
                        PoLine = c.String(),
                        SupplierId = c.Byte(nullable: false),
                        CustomerOrderNumber = c.String(nullable: false),
                        SoNumber = c.String(),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ReceivedQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ReceiptDateTime = c.DateTime(),
                        PoOrderStatusId = c.Byte(nullable: false),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PoOrderStatus_PoOrderStatusId = c.Int(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.PoPlanId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PoOrderStatus", t => t.PoOrderStatus_PoOrderStatusId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PoOrderStatus_PoOrderStatusId)
                .Index(t => t.Supplier_SupplierId);
            
            AddColumn("dbo.TxQohs", "NcrQty", c => c.Int(nullable: false));
            AddColumn("dbo.TxQohs", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PoPlans", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PoPlans", "PoOrderStatus_PoOrderStatusId", "dbo.PoOrderStatus");
            DropForeignKey("dbo.PoPlans", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.PoPlans", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.PoPlans", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.PoPlans", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.PoPlans", new[] { "PoOrderStatus_PoOrderStatusId" });
            DropIndex("dbo.PoPlans", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.PoPlans", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.PoPlans", new[] { "Customer_CustomerId" });
            DropColumn("dbo.TxQohs", "Notes");
            DropColumn("dbo.TxQohs", "NcrQty");
            DropTable("dbo.PoPlans");
        }
    }
}
