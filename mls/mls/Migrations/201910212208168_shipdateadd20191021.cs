namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipdateadd20191021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewWorkOrderViewModels", "ShipDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewWorkOrderViewModels", "ShipDate");
        }
    }
}
