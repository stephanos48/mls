namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wofileadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileWoDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        WorkOrderFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrderFs", t => t.WorkOrderFId, cascadeDelete: true)
                .Index(t => t.WorkOrderFId);
            
            CreateTable(
                "dbo.WorkOrderFs",
                c => new
                    {
                        WorkOrderFId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ContractorId = c.Byte(nullable: false),
                        WoPartTypeId = c.Byte(nullable: false),
                        WorkOrderNumber = c.String(),
                        NeedDate = c.DateTime(),
                        PromiseDate = c.DateTime(),
                        ShipDate = c.DateTime(),
                        CustomerPn = c.String(nullable: false),
                        Qty = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        StartTime = c.String(),
                        FinishTime = c.String(),
                        CloseDate = c.DateTime(),
                        OrderTypeId = c.Byte(nullable: false),
                        SageJournalNo = c.String(),
                        Sn = c.String(),
                        NewSn = c.String(),
                        CustomerPo = c.String(),
                        MlsSo = c.String(),
                        WoOrderStatusId = c.Byte(nullable: false),
                        PartStockOutId = c.Byte(nullable: false),
                        WoNotes = c.String(),
                        PartsNeeded = c.String(),
                        PartStockOutNotes = c.String(),
                        Parts = c.String(),
                        Equipment = c.String(),
                        Resources = c.String(),
                        Notes = c.String(),
                        Day1 = c.String(),
                        Day2 = c.String(),
                        Day3 = c.String(),
                        Day4 = c.String(),
                        Day5 = c.String(),
                        Day6 = c.String(),
                        Day7 = c.String(),
                        Day8 = c.String(),
                        Day9 = c.String(),
                        Day10 = c.String(),
                        Wk3 = c.String(),
                        Wk4 = c.String(),
                        Wk5 = c.String(),
                        Wk6 = c.String(),
                        Wk7 = c.String(),
                        Wk8 = c.String(),
                        Contractor_ContractorId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        OrderType_OrderTypeId = c.Int(),
                        PartStockOut_PartStockOutId = c.Int(),
                        WoOrderStatus_WoOrderStatusId = c.Int(),
                        WoPartType_WoPartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkOrderFId)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderType_OrderTypeId)
                .ForeignKey("dbo.PartStockOuts", t => t.PartStockOut_PartStockOutId)
                .ForeignKey("dbo.WoOrderStatus", t => t.WoOrderStatus_WoOrderStatusId)
                .ForeignKey("dbo.WoPartTypes", t => t.WoPartType_WoPartTypeId)
                .Index(t => t.Contractor_ContractorId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.OrderType_OrderTypeId)
                .Index(t => t.PartStockOut_PartStockOutId)
                .Index(t => t.WoOrderStatus_WoOrderStatusId)
                .Index(t => t.WoPartType_WoPartTypeId);
            
            CreateTable(
                "dbo.WoFDetails",
                c => new
                    {
                        WoFDetailId = c.Int(nullable: false, identity: true),
                        WorkDate = c.DateTime(),
                        WoResponsible = c.String(),
                        Objective = c.String(),
                        StartTime = c.String(),
                        FinishTime = c.String(),
                        TotalTime = c.Decimal(precision: 18, scale: 2),
                        Risk = c.String(),
                        RiskAction = c.String(),
                        Productive = c.String(),
                        Notes = c.String(),
                        WorkOrderFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WoFDetailId)
                .ForeignKey("dbo.WorkOrderFs", t => t.WorkOrderFId, cascadeDelete: true)
                .Index(t => t.WorkOrderFId);
            
            CreateTable(
                "dbo.WorkOrderLogs",
                c => new
                    {
                        WorkOrderLogId = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        EventDateTime = c.DateTime(),
                        EventType = c.String(),
                        WorkOrderFId = c.Int(nullable: false),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        ContractorId = c.Byte(nullable: false),
                        WoPartTypeId = c.Byte(nullable: false),
                        WorkOrderNumber = c.String(),
                        NeedDate = c.DateTime(),
                        PromiseDate = c.DateTime(),
                        ShipDate = c.DateTime(),
                        CustomerPn = c.String(nullable: false),
                        Qty = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        StartTime = c.String(),
                        FinishTime = c.String(),
                        CloseDate = c.DateTime(),
                        OrderTypeId = c.Byte(nullable: false),
                        SageJournalNo = c.String(),
                        Sn = c.String(),
                        NewSn = c.String(),
                        CustomerPo = c.String(),
                        MlsSo = c.String(),
                        WoOrderStatusId = c.Byte(nullable: false),
                        PartStockOutId = c.Byte(nullable: false),
                        WoNotes = c.String(),
                        PartsNeeded = c.String(),
                        PartStockOutNotes = c.String(),
                        Parts = c.String(),
                        Equipment = c.String(),
                        Resources = c.String(),
                        Notes = c.String(),
                        Contractor_ContractorId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        OrderType_OrderTypeId = c.Int(),
                        PartStockOut_PartStockOutId = c.Int(),
                        WoOrderStatus_WoOrderStatusId = c.Int(),
                        WoPartType_WoPartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkOrderLogId)
                .ForeignKey("dbo.Contractors", t => t.Contractor_ContractorId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderType_OrderTypeId)
                .ForeignKey("dbo.PartStockOuts", t => t.PartStockOut_PartStockOutId)
                .ForeignKey("dbo.WoOrderStatus", t => t.WoOrderStatus_WoOrderStatusId)
                .ForeignKey("dbo.WoPartTypes", t => t.WoPartType_WoPartTypeId)
                .Index(t => t.Contractor_ContractorId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.OrderType_OrderTypeId)
                .Index(t => t.PartStockOut_PartStockOutId)
                .Index(t => t.WoOrderStatus_WoOrderStatusId)
                .Index(t => t.WoPartType_WoPartTypeId);
            
            AddColumn("dbo.DownReports", "WorkOrderF_WorkOrderFId", c => c.Int());
            CreateIndex("dbo.DownReports", "WorkOrderF_WorkOrderFId");
            AddForeignKey("dbo.DownReports", "WorkOrderF_WorkOrderFId", "dbo.WorkOrderFs", "WorkOrderFId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrderLogs", "WoPartType_WoPartTypeId", "dbo.WoPartTypes");
            DropForeignKey("dbo.WorkOrderLogs", "WoOrderStatus_WoOrderStatusId", "dbo.WoOrderStatus");
            DropForeignKey("dbo.WorkOrderLogs", "PartStockOut_PartStockOutId", "dbo.PartStockOuts");
            DropForeignKey("dbo.WorkOrderLogs", "OrderType_OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.WorkOrderLogs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.WorkOrderLogs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.WorkOrderLogs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.WorkOrderLogs", "Contractor_ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.WorkOrderFs", "WoPartType_WoPartTypeId", "dbo.WoPartTypes");
            DropForeignKey("dbo.WorkOrderFs", "WoOrderStatus_WoOrderStatusId", "dbo.WoOrderStatus");
            DropForeignKey("dbo.WoFDetails", "WorkOrderFId", "dbo.WorkOrderFs");
            DropForeignKey("dbo.WorkOrderFs", "PartStockOut_PartStockOutId", "dbo.PartStockOuts");
            DropForeignKey("dbo.WorkOrderFs", "OrderType_OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.WorkOrderFs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.FileWoDetails", "WorkOrderFId", "dbo.WorkOrderFs");
            DropForeignKey("dbo.DownReports", "WorkOrderF_WorkOrderFId", "dbo.WorkOrderFs");
            DropForeignKey("dbo.WorkOrderFs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.WorkOrderFs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.WorkOrderFs", "Contractor_ContractorId", "dbo.Contractors");
            DropIndex("dbo.WorkOrderLogs", new[] { "WoPartType_WoPartTypeId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "WoOrderStatus_WoOrderStatusId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "PartStockOut_PartStockOutId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "OrderType_OrderTypeId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.WorkOrderLogs", new[] { "Contractor_ContractorId" });
            DropIndex("dbo.WoFDetails", new[] { "WorkOrderFId" });
            DropIndex("dbo.WorkOrderFs", new[] { "WoPartType_WoPartTypeId" });
            DropIndex("dbo.WorkOrderFs", new[] { "WoOrderStatus_WoOrderStatusId" });
            DropIndex("dbo.WorkOrderFs", new[] { "PartStockOut_PartStockOutId" });
            DropIndex("dbo.WorkOrderFs", new[] { "OrderType_OrderTypeId" });
            DropIndex("dbo.WorkOrderFs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.WorkOrderFs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.WorkOrderFs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.WorkOrderFs", new[] { "Contractor_ContractorId" });
            DropIndex("dbo.FileWoDetails", new[] { "WorkOrderFId" });
            DropIndex("dbo.DownReports", new[] { "WorkOrderF_WorkOrderFId" });
            DropColumn("dbo.DownReports", "WorkOrderF_WorkOrderFId");
            DropTable("dbo.WorkOrderLogs");
            DropTable("dbo.WoFDetails");
            DropTable("dbo.WorkOrderFs");
            DropTable("dbo.FileWoDetails");
        }
    }
}
