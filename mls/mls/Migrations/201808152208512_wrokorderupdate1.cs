namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wrokorderupdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "WoNotes", c => c.String());
            AddColumn("dbo.WorkOrders", "Day1", c => c.String());
            AddColumn("dbo.WorkOrders", "Day2", c => c.String());
            AddColumn("dbo.WorkOrders", "Day3", c => c.String());
            AddColumn("dbo.WorkOrders", "Day4", c => c.String());
            AddColumn("dbo.WorkOrders", "Day5", c => c.String());
            AddColumn("dbo.WorkOrders", "Day6", c => c.String());
            AddColumn("dbo.WorkOrders", "Day7", c => c.String());
            AddColumn("dbo.WorkOrders", "Day8", c => c.String());
            AddColumn("dbo.WorkOrders", "Day9", c => c.String());
            AddColumn("dbo.WorkOrders", "Day10", c => c.String());
            AddColumn("dbo.WorkOrders", "Wk3", c => c.String());
            AddColumn("dbo.WorkOrders", "Wk4", c => c.String());
            AddColumn("dbo.WorkOrders", "Wk5", c => c.String());
            AddColumn("dbo.WorkOrders", "Wk6", c => c.String());
            AddColumn("dbo.WorkOrders", "Wk7", c => c.String());
            AddColumn("dbo.WorkOrders", "Wk8", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "Wk8");
            DropColumn("dbo.WorkOrders", "Wk7");
            DropColumn("dbo.WorkOrders", "Wk6");
            DropColumn("dbo.WorkOrders", "Wk5");
            DropColumn("dbo.WorkOrders", "Wk4");
            DropColumn("dbo.WorkOrders", "Wk3");
            DropColumn("dbo.WorkOrders", "Day10");
            DropColumn("dbo.WorkOrders", "Day9");
            DropColumn("dbo.WorkOrders", "Day8");
            DropColumn("dbo.WorkOrders", "Day7");
            DropColumn("dbo.WorkOrders", "Day6");
            DropColumn("dbo.WorkOrders", "Day5");
            DropColumn("dbo.WorkOrders", "Day4");
            DropColumn("dbo.WorkOrders", "Day3");
            DropColumn("dbo.WorkOrders", "Day2");
            DropColumn("dbo.WorkOrders", "Day1");
            DropColumn("dbo.WorkOrders", "WoNotes");
        }
    }
}
