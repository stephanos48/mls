namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodschedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionPlans",
                c => new
                    {
                        ProductionPlanId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        Description = c.String(),
                        TotalOrders = c.Int(),
                        OnHold = c.Int(),
                        Schedule = c.Int(),
                        Day1 = c.Int(),
                        Day2 = c.Int(),
                        Day3 = c.Int(),
                        Day4 = c.Int(),
                        Day5 = c.Int(),
                        Day6 = c.Int(),
                        Day7 = c.Int(),
                        Day8 = c.Int(),
                        Day9 = c.Int(),
                        Day10 = c.Int(),
                        Wk3 = c.Int(),
                        Wk4 = c.Int(),
                        Wk5 = c.Int(),
                        Wk6 = c.Int(),
                        Wk7 = c.Int(),
                        Wk8 = c.Int(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ProductionPlanId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductionPlans");
        }
    }
}
