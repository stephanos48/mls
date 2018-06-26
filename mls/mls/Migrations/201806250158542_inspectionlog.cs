namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inspectionlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncomingLogs",
                c => new
                    {
                        IncomingLogId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        InspectionType = c.String(),
                        InspectionLength = c.String(),
                        IncomingStartDate = c.DateTime(),
                        IncomingRemovalDate = c.DateTime(),
                        InspectionMethod = c.String(),
                        InspectionCriteria = c.String(),
                        InspectionStatusId = c.Byte(nullable: false),
                        Notes = c.String(),
                        InspectionStatus_InspectionStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomingLogId)
                .ForeignKey("dbo.InspectionStatus", t => t.InspectionStatus_InspectionStatusId)
                .Index(t => t.InspectionStatus_InspectionStatusId);
            
            CreateTable(
                "dbo.InspectionStatus",
                c => new
                    {
                        InspectionStatusId = c.Int(nullable: false, identity: true),
                        InspectionStatusName = c.String(),
                    })
                .PrimaryKey(t => t.InspectionStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomingLogs", "InspectionStatus_InspectionStatusId", "dbo.InspectionStatus");
            DropIndex("dbo.IncomingLogs", new[] { "InspectionStatus_InspectionStatusId" });
            DropTable("dbo.InspectionStatus");
            DropTable("dbo.IncomingLogs");
        }
    }
}
