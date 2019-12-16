namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwono20191015 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipPlans", "WoNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipPlans", "WoNumber");
        }
    }
}
