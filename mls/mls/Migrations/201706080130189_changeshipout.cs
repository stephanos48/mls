namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeshipout : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShipOuts", "ShipDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShipOuts", "ShipDate", c => c.String());
        }
    }
}
