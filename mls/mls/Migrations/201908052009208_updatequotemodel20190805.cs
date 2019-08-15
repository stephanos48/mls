namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatequotemodel20190805 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerQuotes", "QuotedPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerQuotes", "QuotedPrice", c => c.String());
        }
    }
}
