namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestatusint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerOrders", "ShipQty", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerOrders", "ShipQty", c => c.Int(nullable: false));
        }
    }
}
