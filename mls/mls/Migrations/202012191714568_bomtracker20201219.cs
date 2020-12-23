namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bomtracker20201219 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BomStatus",
                c => new
                    {
                        BomStatusId = c.Int(nullable: false, identity: true),
                        BomStatusName = c.String(),
                    })
                .PrimaryKey(t => t.BomStatusId);
            
            CreateTable(
                "dbo.BomTrackers",
                c => new
                    {
                        BomTrackerId = c.Int(nullable: false, identity: true),
                        BomStatusId = c.Byte(nullable: false),
                        BomPn = c.String(),
                        Description = c.String(),
                        RevLevel = c.String(),
                        BomCreatorExcel = c.String(),
                        DateCreatedExcel = c.DateTime(),
                        BomCreatorSage = c.String(),
                        DateCreatedSage = c.DateTime(),
                        BomCreatorPortal = c.String(),
                        DateCreatedPortal = c.DateTime(),
                        ApprovedBy = c.String(),
                        DateApproved = c.DateTime(),
                        Notes = c.String(),
                        BomStatus_BomStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.BomTrackerId)
                .ForeignKey("dbo.BomStatus", t => t.BomStatus_BomStatusId)
                .Index(t => t.BomStatus_BomStatusId);
            
            CreateTable(
                "dbo.FileBomDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        BomTrackerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BomTrackers", t => t.BomTrackerId, cascadeDelete: true)
                .Index(t => t.BomTrackerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileBomDetails", "BomTrackerId", "dbo.BomTrackers");
            DropForeignKey("dbo.BomTrackers", "BomStatus_BomStatusId", "dbo.BomStatus");
            DropIndex("dbo.FileBomDetails", new[] { "BomTrackerId" });
            DropIndex("dbo.BomTrackers", new[] { "BomStatus_BomStatusId" });
            DropTable("dbo.FileBomDetails");
            DropTable("dbo.BomTrackers");
            DropTable("dbo.BomStatus");
        }
    }
}
