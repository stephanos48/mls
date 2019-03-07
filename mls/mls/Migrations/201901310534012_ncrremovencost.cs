namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncrremovencost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NCRs", "ReworkCost");
            DropColumn("dbo.NCRs", "ScrapCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NCRs", "ScrapCost", c => c.Int(nullable: false));
            AddColumn("dbo.NCRs", "ReworkCost", c => c.Int(nullable: false));
        }
    }
}
