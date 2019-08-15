namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poplanchanges20190803 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PoPlans", "ContainerUh", c => c.String());
            AddColumn("dbo.PoPlans", "FreightFowarder", c => c.String());
            AddColumn("dbo.PoPlans", "Destination", c => c.String());
            AddColumn("dbo.PoPlans", "AMS", c => c.String());
            AddColumn("dbo.PoPlans", "Pallet", c => c.String());
            AddColumn("dbo.PoPlans", "Shipdate", c => c.DateTime());
            AlterColumn("dbo.PoPlans", "CustomerOrderNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PoPlans", "CustomerOrderNumber", c => c.String(nullable: false));
            DropColumn("dbo.PoPlans", "Shipdate");
            DropColumn("dbo.PoPlans", "Pallet");
            DropColumn("dbo.PoPlans", "AMS");
            DropColumn("dbo.PoPlans", "Destination");
            DropColumn("dbo.PoPlans", "FreightFowarder");
            DropColumn("dbo.PoPlans", "ContainerUh");
        }
    }
}
