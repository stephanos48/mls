namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productionstockout20190308 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrderDownReports",
                c => new
                    {
                        WorkOrder_WorkOrderId = c.Int(nullable: false),
                        DownReport_DownReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkOrder_WorkOrderId, t.DownReport_DownReportId })
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrder_WorkOrderId, cascadeDelete: true)
                .ForeignKey("dbo.DownReports", t => t.DownReport_DownReportId, cascadeDelete: true)
                .Index(t => t.WorkOrder_WorkOrderId)
                .Index(t => t.DownReport_DownReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrderDownReports", "DownReport_DownReportId", "dbo.DownReports");
            DropForeignKey("dbo.WorkOrderDownReports", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropIndex("dbo.WorkOrderDownReports", new[] { "DownReport_DownReportId" });
            DropIndex("dbo.WorkOrderDownReports", new[] { "WorkOrder_WorkOrderId" });
            DropTable("dbo.WorkOrderDownReports");
        }
    }
}
