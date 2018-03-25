namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woredo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WoDetails",
                c => new
                    {
                        WoDetailId = c.Int(nullable: false, identity: true),
                        WorkDate = c.DateTime(),
                        Employee = c.String(),
                        Objective = c.String(),
                        StartTime = c.String(),
                        FinishTime = c.String(),
                        TotalTime = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Risk = c.String(),
                        RiskAction = c.String(),
                        Productive = c.String(),
                        Notes = c.String(),
                        WorkOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WoDetailId)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrderId, cascadeDelete: true)
                .Index(t => t.WorkOrderId);
            
            AddColumn("dbo.WorkOrders", "NeedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WoDetails", "WorkOrderId", "dbo.WorkOrders");
            DropIndex("dbo.WoDetails", new[] { "WorkOrderId" });
            DropColumn("dbo.WorkOrders", "NeedDate");
            DropTable("dbo.WoDetails");
        }
    }
}
