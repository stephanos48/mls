namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class downreport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DownStatus",
                c => new
                    {
                        DownStatusId = c.Int(nullable: false, identity: true),
                        DownStatusType = c.String(),
                    })
                .PrimaryKey(t => t.DownStatusId);
            
            AddColumn("dbo.DownReports", "MlsDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.DownReports", "DownStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.DownReports", "DownStatus_DownStatusId", c => c.Int());
            CreateIndex("dbo.DownReports", "DownStatus_DownStatusId");
            AddForeignKey("dbo.DownReports", "DownStatus_DownStatusId", "dbo.DownStatus", "DownStatusId");
            DropColumn("dbo.DownReports", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DownReports", "Status", c => c.String());
            DropForeignKey("dbo.DownReports", "DownStatus_DownStatusId", "dbo.DownStatus");
            DropIndex("dbo.DownReports", new[] { "DownStatus_DownStatusId" });
            DropColumn("dbo.DownReports", "DownStatus_DownStatusId");
            DropColumn("dbo.DownReports", "DownStatusId");
            DropColumn("dbo.DownReports", "MlsDivisionId");
            DropTable("dbo.DownStatus");
        }
    }
}
