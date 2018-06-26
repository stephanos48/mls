namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incomingkey : DbMigration
    {
        public override void Up()
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
                        IncomingDetailId = c.Int(nullable: false, identity: true),
                        InspectionDateTime = c.DateTime(),
                        PartNumber = c.String(),
                        SerialNumber = c.String(),
                        InspectionCriteria = c.String(),
                        InspectionType = c.String(),
                        QtyReceived = c.Int(),
                        QtyInspected = c.Int(),
                        QtyGood = c.Int(),
                        QtyBad = c.Int(),
                        InspectorName = c.String(),
                        Notes = c.String(),
                        IncomingTopLevel_IncomingTopLevelId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomingDetailId)
                .ForeignKey("dbo.IncomingTopLevels", t => t.IncomingTopLevel_IncomingTopLevelId)
                .Index(t => t.IncomingTopLevel_IncomingTopLevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId", "dbo.IncomingTopLevels");
            DropIndex("dbo.IncomingDetails", new[] { "IncomingTopLevel_IncomingTopLevelId" });
            DropTable("dbo.IncomingDetails");
            DropTable("dbo.IncomingTopLevels");
        }
    }
}
