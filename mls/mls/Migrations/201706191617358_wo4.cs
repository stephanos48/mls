namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wo4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewWorkOrderViewModels",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        WorkOrderNumber = c.String(),
                        CustomerPn = c.String(nullable: false),
                        Qty = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        CloseDate = c.DateTime(),
                        OrderTypeId = c.Byte(nullable: false),
                        Sn = c.String(),
                        CustomerPo = c.String(),
                        MlsSo = c.String(),
                        WoOrderStatusId = c.Byte(nullable: false),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        OrderType_OrderTypeId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                        WoOrderStatus_WoOrderStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderType_OrderTypeId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .ForeignKey("dbo.WoOrderStatus", t => t.WoOrderStatus_WoOrderStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.OrderType_OrderTypeId)
                .Index(t => t.PartType_PartTypeId)
                .Index(t => t.WoOrderStatus_WoOrderStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewWorkOrderViewModels", "WoOrderStatus_WoOrderStatusId", "dbo.WoOrderStatus");
            DropForeignKey("dbo.NewWorkOrderViewModels", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.NewWorkOrderViewModels", "OrderType_OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.NewWorkOrderViewModels", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.NewWorkOrderViewModels", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.NewWorkOrderViewModels", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "WoOrderStatus_WoOrderStatusId" });
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "OrderType_OrderTypeId" });
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "Customer_CustomerId" });
            DropTable("dbo.NewWorkOrderViewModels");
        }
    }
}
