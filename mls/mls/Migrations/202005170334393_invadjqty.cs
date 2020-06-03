namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invadjqty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CycleCounts", "SageAdjQty", c => c.Int(nullable: false));
            AddColumn("dbo.CycleCounts", "PortalAdjQty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CycleCounts", "PortalAdjQty");
            DropColumn("dbo.CycleCounts", "SageAdjQty");
        }
    }
}
