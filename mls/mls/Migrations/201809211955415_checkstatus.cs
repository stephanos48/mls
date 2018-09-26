namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkstatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckStatus",
                c => new
                    {
                        CheckStatusId = c.Int(nullable: false, identity: true),
                        CheckStatusName = c.String(),
                    })
                .PrimaryKey(t => t.CheckStatusId);
            
            AddColumn("dbo.CheckRequests", "CheckStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.CheckRequests", "Amount", c => c.String());
            AddColumn("dbo.CheckRequests", "CheckStatus_CheckStatusId", c => c.Int());
            CreateIndex("dbo.CheckRequests", "CheckStatus_CheckStatusId");
            AddForeignKey("dbo.CheckRequests", "CheckStatus_CheckStatusId", "dbo.CheckStatus", "CheckStatusId");
            DropColumn("dbo.CheckRequests", "CheckStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckRequests", "CheckStatus", c => c.String());
            DropForeignKey("dbo.CheckRequests", "CheckStatus_CheckStatusId", "dbo.CheckStatus");
            DropIndex("dbo.CheckRequests", new[] { "CheckStatus_CheckStatusId" });
            DropColumn("dbo.CheckRequests", "CheckStatus_CheckStatusId");
            DropColumn("dbo.CheckRequests", "Amount");
            DropColumn("dbo.CheckRequests", "CheckStatusId");
            DropTable("dbo.CheckStatus");
        }
    }
}
