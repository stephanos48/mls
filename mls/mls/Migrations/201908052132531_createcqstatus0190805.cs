namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createcqstatus0190805 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerQuotes", "CurrentPriceId", "dbo.CurrentPrices");
            DropIndex("dbo.CustomerQuotes", new[] { "CurrentPriceId" });
            CreateTable(
                "dbo.CQStatus",
                c => new
                    {
                        CQStatusId = c.Int(nullable: false, identity: true),
                        CQName = c.String(),
                    })
                .PrimaryKey(t => t.CQStatusId);
            
            AddColumn("dbo.CustomerQuotes", "CQStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerQuotes", "CQStatusId");
            AddForeignKey("dbo.CustomerQuotes", "CQStatusId", "dbo.CQStatus", "CQStatusId", cascadeDelete: true);
            DropColumn("dbo.CustomerQuotes", "CurrentPriceId");
            DropTable("dbo.CurrentPrices");
        }
        
        public override void Down()
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
            DropForeignKey("dbo.CustomerQuotes", "CQStatusId", "dbo.CQStatus");
            DropIndex("dbo.CustomerQuotes", new[] { "CQStatusId" });
            DropColumn("dbo.CustomerQuotes", "CQStatusId");
            DropTable("dbo.CQStatus");
            CreateIndex("dbo.CustomerQuotes", "CurrentPriceId");
            AddForeignKey("dbo.CustomerQuotes", "CurrentPriceId", "dbo.CurrentPrices", "CurrentPriceId", cascadeDelete: true);
        }
    }
}
