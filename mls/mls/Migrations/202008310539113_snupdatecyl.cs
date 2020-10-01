namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class snupdatecyl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "NewSn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "NewSn");
        }
    }
}
