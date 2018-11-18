namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerquote20181118 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerQuotes", "MlsDivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerQuotes", "Eau", c => c.String());
            AddColumn("dbo.CustomerQuotes", "ChinaBom", c => c.String());
            AddColumn("dbo.CustomerQuotes", "Weight", c => c.String());
            AddColumn("dbo.CustomerQuotes", "ExchangeRate", c => c.String());
            CreateIndex("dbo.CustomerQuotes", "MlsDivisionId");
            AddForeignKey("dbo.CustomerQuotes", "MlsDivisionId", "dbo.MlsDivisions", "MlsDivisionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerQuotes", "MlsDivisionId", "dbo.MlsDivisions");
            DropIndex("dbo.CustomerQuotes", new[] { "MlsDivisionId" });
            DropColumn("dbo.CustomerQuotes", "ExchangeRate");
            DropColumn("dbo.CustomerQuotes", "Weight");
            DropColumn("dbo.CustomerQuotes", "ChinaBom");
            DropColumn("dbo.CustomerQuotes", "Eau");
            DropColumn("dbo.CustomerQuotes", "MlsDivisionId");
        }
    }
}
