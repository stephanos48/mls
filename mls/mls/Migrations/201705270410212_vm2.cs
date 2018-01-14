namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vm2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewOrderViewModels",
                c => new
                    {
                        CustomerOrderId = c.Int(nullable: false, identity: true),
                        CustomerOrderNumber = c.String(),
                        OrderDateTime = c.DateTime(),
                        CustomerPn = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ShipQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ShipDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CustomerOrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewOrderViewModels");
        }
    }
}
