namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppupdatestatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductionPlans", "TotalOrders", c => c.String());
            AlterColumn("dbo.ProductionPlans", "OnHold", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Schedule", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day1", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day2", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day3", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day4", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day5", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day6", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day7", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day8", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day9", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Day10", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Wk3", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Wk4", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Wk5", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Wk6", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Wk7", c => c.String());
            AlterColumn("dbo.ProductionPlans", "Wk8", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductionPlans", "Wk8", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Wk7", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Wk6", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Wk5", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Wk4", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Wk3", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day10", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day9", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day8", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day7", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day6", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day5", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day4", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day3", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day2", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Day1", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "Schedule", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "OnHold", c => c.Int());
            AlterColumn("dbo.ProductionPlans", "TotalOrders", c => c.Int());
        }
    }
}
