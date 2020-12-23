namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinvno20201220 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipPlanFs", "InvNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipPlanFs", "InvNo");
        }
    }
}
