namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendarupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarWks", "CommitWks_CommitWkId", c => c.Int());
            AddColumn("dbo.CalendarWks", "DemandWks_DemandWkId", c => c.Int());
            AddColumn("dbo.CommitWks", "CalendarWk", c => c.String());
            AddColumn("dbo.DemandWks", "CalendarWk", c => c.String());
            CreateIndex("dbo.CalendarWks", "CommitWks_CommitWkId");
            CreateIndex("dbo.CalendarWks", "DemandWks_DemandWkId");
            AddForeignKey("dbo.CalendarWks", "CommitWks_CommitWkId", "dbo.CommitWks", "CommitWkId");
            AddForeignKey("dbo.CalendarWks", "DemandWks_DemandWkId", "dbo.DemandWks", "DemandWkId");
            DropColumn("dbo.CommitWks", "WkYr");
            DropColumn("dbo.DemandWks", "WkYr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DemandWks", "WkYr", c => c.String());
            AddColumn("dbo.CommitWks", "WkYr", c => c.String());
            DropForeignKey("dbo.CalendarWks", "DemandWks_DemandWkId", "dbo.DemandWks");
            DropForeignKey("dbo.CalendarWks", "CommitWks_CommitWkId", "dbo.CommitWks");
            DropIndex("dbo.CalendarWks", new[] { "DemandWks_DemandWkId" });
            DropIndex("dbo.CalendarWks", new[] { "CommitWks_CommitWkId" });
            DropColumn("dbo.DemandWks", "CalendarWk");
            DropColumn("dbo.CommitWks", "CalendarWk");
            DropColumn("dbo.CalendarWks", "DemandWks_DemandWkId");
            DropColumn("dbo.CalendarWks", "CommitWks_CommitWkId");
        }
    }
}
