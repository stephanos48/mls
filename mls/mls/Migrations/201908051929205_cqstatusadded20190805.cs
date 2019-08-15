namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cqstatusadded20190805 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentPrices",
                c => new
                    {
                        CurrentPriceId = c.Int(nullable: false, identity: true),
                        CurrentPriceName = c.String(),
                    })
                .PrimaryKey(t => t.CurrentPriceId);
            
            AddColumn("dbo.CustomerQuotes", "CurrentPriceId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerQuotes", "QuotedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.CustomerQuotes", "CurrentPriceId");
            AddForeignKey("dbo.CustomerQuotes", "CurrentPriceId", "dbo.CurrentPrices", "CurrentPriceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerQuotes", "CurrentPriceId", "dbo.CurrentPrices");
            DropIndex("dbo.CustomerQuotes", new[] { "CurrentPriceId" });
            AlterColumn("dbo.CustomerQuotes", "QuotedPrice", c => c.String());
            DropColumn("dbo.CustomerQuotes", "CurrentPriceId");
            DropTable("dbo.CurrentPrices");
        }
    }
}
