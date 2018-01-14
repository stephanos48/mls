namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wov1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.WorkOrders");
            DropColumn("dbo.WorkOrders", "WorId");
            AddColumn("dbo.WorkOrders", "WorkOrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.WorkOrders", "CustomerId", c => c.Byte(nullable: false));
            AddColumn("dbo.WorkOrders", "CustomerDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.WorkOrders", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.WorkOrders", "CustomerDivision_CustomerDivisionId", c => c.Int());
            AddPrimaryKey("dbo.WorkOrders", "WorkOrderId");
            CreateIndex("dbo.WorkOrders", "Customer_CustomerId");
            CreateIndex("dbo.WorkOrders", "CustomerDivision_CustomerDivisionId");
            AddForeignKey("dbo.WorkOrders", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.WorkOrders", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrders", "WorId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.WorkOrders", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.WorkOrders", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.WorkOrders", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.WorkOrders", new[] { "Customer_CustomerId" });
            DropPrimaryKey("dbo.WorkOrders");
            DropColumn("dbo.WorkOrders", "CustomerDivision_CustomerDivisionId");
            DropColumn("dbo.WorkOrders", "Customer_CustomerId");
            DropColumn("dbo.WorkOrders", "CustomerDivisionId");
            DropColumn("dbo.WorkOrders", "CustomerId");
            DropColumn("dbo.WorkOrders", "WorkOrderId");
            AddPrimaryKey("dbo.WorkOrders", "WorId");
        }
    }
}
