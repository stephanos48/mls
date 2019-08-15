namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecqprice20190805 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerQuotes", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CustomerQuotes", "QuotedPrice", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerQuotes", "QuotedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CustomerQuotes", "TotalPrice");
        }
    }
}
