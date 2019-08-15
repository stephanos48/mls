namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class operatorcqstatusupdate20190805 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerQuotes", "TotalPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerQuotes", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
