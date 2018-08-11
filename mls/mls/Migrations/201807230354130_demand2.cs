namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demand2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipIns", "ArrivalWk", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipIns", "ArrivalWk");
        }
    }
}
