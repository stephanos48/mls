namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeincoming : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId", "dbo.IncomingTopLevels");
            DropIndex("dbo.IncomingDetails", new[] { "IncomingTopLevel_IncomingTopLevelId" });
            DropTable("dbo.IncomingDetails");
            DropTable("dbo.IncomingTopLevels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IncomingTopLevels",
                c => new
                    {
                        IncomingTopLevelId = c.Int(nullable: false, identity: true),
                        IncomingVesselNo = c.String(),
                        InspectionDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.IncomingTopLevelId);
            
            CreateTable(
                "dbo.IncomingDetails",
                c => new
                    {
                        IncomingDetailsId = c.Int(nullable: false, identity: true),
                        InspectionDateTime = c.DateTime(),
                        PartNumber = c.String(),
                        SerialNumber = c.String(),
                        InspectionCriteria = c.String(),
                        InspectionType = c.String(),
                        QtyReceived = c.Int(nullable: false),
                        QtyInspected = c.Int(nullable: false),
                        QtyGood = c.Int(nullable: false),
                        QtyBad = c.Int(nullable: false),
                        InspectorName = c.String(),
                        Notes = c.String(),
                        IncomingTopLevel_IncomingTopLevelId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomingDetailsId);
            
            CreateIndex("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId");
            AddForeignKey("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId", "dbo.IncomingTopLevels", "IncomingTopLevelId");
        }
    }
}
