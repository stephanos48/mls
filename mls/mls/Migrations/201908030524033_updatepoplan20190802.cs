namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepoplan20190802 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PoPlans", "ContainerId", c => c.String());
            AddColumn("dbo.PoPlans", "BOL", c => c.String());
            AddColumn("dbo.PoPlans", "Invoice", c => c.String());
            AddColumn("dbo.PoPlans", "ArrivalWk", c => c.String());
            AddColumn("dbo.PoPlans", "Etadate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PoPlans", "Etadate");
            DropColumn("dbo.PoPlans", "ArrivalWk");
            DropColumn("dbo.PoPlans", "Invoice");
            DropColumn("dbo.PoPlans", "BOL");
            DropColumn("dbo.PoPlans", "ContainerId");
        }
    }
}
