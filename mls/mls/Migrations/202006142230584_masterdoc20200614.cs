namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masterdoc20200614 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocStatus",
                c => new
                    {
                        DocStatusId = c.Int(nullable: false, identity: true),
                        DocStatusName = c.String(),
                    })
                .PrimaryKey(t => t.DocStatusId);
            
            CreateTable(
                "dbo.FileDocDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        MasterDocId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MasterDocs", t => t.MasterDocId, cascadeDelete: true)
                .Index(t => t.MasterDocId);
            
            CreateTable(
                "dbo.MasterDocs",
                c => new
                    {
                        MasterDocId = c.Int(nullable: false, identity: true),
                        DocStatusId = c.Byte(nullable: false),
                        DocNo = c.String(),
                        DocTitle = c.String(),
                        DocOwner = c.String(),
                        RevLevel = c.String(),
                        SecuredLocation = c.String(),
                        ProtectionMethod = c.String(),
                        RetentionPeriod = c.String(),
                        LastReviewed = c.DateTime(),
                        ReviewedBy = c.String(),
                        NextReview = c.DateTime(),
                        ControlledBy = c.String(),
                        ElecDistribution = c.String(),
                        DistributionMethod = c.String(),
                        RecordStorageLocation = c.String(),
                        RecordDistributionMethod = c.String(),
                        AssociatedDocs = c.String(),
                        Notes = c.String(),
                        DocStatus_DocStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.MasterDocId)
                .ForeignKey("dbo.DocStatus", t => t.DocStatus_DocStatusId)
                .Index(t => t.DocStatus_DocStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDocDetails", "MasterDocId", "dbo.MasterDocs");
            DropForeignKey("dbo.MasterDocs", "DocStatus_DocStatusId", "dbo.DocStatus");
            DropIndex("dbo.MasterDocs", new[] { "DocStatus_DocStatusId" });
            DropIndex("dbo.FileDocDetails", new[] { "MasterDocId" });
            DropTable("dbo.MasterDocs");
            DropTable("dbo.FileDocDetails");
            DropTable("dbo.DocStatus");
        }
    }
}
