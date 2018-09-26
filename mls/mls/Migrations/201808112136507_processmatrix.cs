namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class processmatrix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcessMatrices",
                c => new
                    {
                        ProcessMatrixId = c.Int(nullable: false, identity: true),
                        ProcessStatusId = c.Byte(nullable: false),
                        DocumentNo = c.String(),
                        DocumentTitle = c.String(),
                        RevLevel = c.String(),
                        SecuredStoreLocation = c.String(),
                        ProtectionMethod = c.String(),
                        RetentionPeriod = c.String(),
                        ControlledBy = c.String(),
                        ElectronicDistribution = c.String(),
                        DistributionMethod = c.String(),
                        RecordStorageLocation = c.String(),
                        RecordDispostionMethod = c.String(),
                        DocumentOwner = c.String(),
                        Notes = c.String(),
                        PicUrl = c.String(),
                        ProcessStatus_ProcessStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ProcessMatrixId)
                .ForeignKey("dbo.ProcessStatus", t => t.ProcessStatus_ProcessStatusId)
                .Index(t => t.ProcessStatus_ProcessStatusId);
            
            CreateTable(
                "dbo.ProcessStatus",
                c => new
                    {
                        ProcessStatusId = c.Int(nullable: false, identity: true),
                        ProcessStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ProcessStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProcessMatrices", "ProcessStatus_ProcessStatusId", "dbo.ProcessStatus");
            DropIndex("dbo.ProcessMatrices", new[] { "ProcessStatus_ProcessStatusId" });
            DropTable("dbo.ProcessStatus");
            DropTable("dbo.ProcessMatrices");
        }
    }
}
