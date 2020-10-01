namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woupdate20200831 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WoBuilds", "ContractorId", c => c.Byte(nullable: false));
            AddColumn("dbo.WoBuilds", "Contractor_ContractorId", c => c.Int());
            CreateIndex("dbo.WoBuilds", "Contractor_ContractorId");
            AddForeignKey("dbo.WoBuilds", "Contractor_ContractorId", "dbo.Contractors", "ContractorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WoBuilds", "Contractor_ContractorId", "dbo.Contractors");
            DropIndex("dbo.WoBuilds", new[] { "Contractor_ContractorId" });
            DropColumn("dbo.WoBuilds", "Contractor_ContractorId");
            DropColumn("dbo.WoBuilds", "ContractorId");
        }
    }
}
