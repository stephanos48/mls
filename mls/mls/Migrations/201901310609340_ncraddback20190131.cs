namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncraddback20190131 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NCRs", "ReworkCost", c => c.String());
            AddColumn("dbo.NCRs", "ScrapCost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NCRs", "ScrapCost");
            DropColumn("dbo.NCRs", "ReworkCost");
        }
    }
}
