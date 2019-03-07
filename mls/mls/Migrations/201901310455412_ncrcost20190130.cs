namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncrcost20190130 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NCRs", "ReworkCost", c => c.Int(nullable: false));
            AddColumn("dbo.NCRs", "ScrapCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NCRs", "ScrapCost");
            DropColumn("dbo.NCRs", "ReworkCost");
        }
    }
}
