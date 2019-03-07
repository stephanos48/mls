namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerorderline20190131 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "CustomerOrderLine", c => c.String());
            AddColumn("dbo.PurchaseOrders", "PoLine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "PoLine");
            DropColumn("dbo.CustomerOrders", "CustomerOrderLine");
        }
    }
}
