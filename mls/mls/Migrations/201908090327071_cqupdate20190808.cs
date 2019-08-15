namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cqupdate20190808 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerQuotes", "UsaBom", c => c.String());
            AddColumn("dbo.CustomerQuotes", "FreightCost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerQuotes", "FreightCost");
            DropColumn("dbo.CustomerQuotes", "UsaBom");
        }
    }
}
