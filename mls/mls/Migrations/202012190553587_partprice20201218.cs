namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partprice20201218 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerQuotes", "PartPrice", c => c.String());
            AddColumn("dbo.WorkOrderFs", "CustomerPoLine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrderFs", "CustomerPoLine");
            DropColumn("dbo.CustomerQuotes", "PartPrice");
        }
    }
}
