namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new20190205 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipOuts", "PoNumberLine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipOuts", "PoNumberLine");
        }
    }
}
