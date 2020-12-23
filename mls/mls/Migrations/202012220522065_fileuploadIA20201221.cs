namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileuploadIA20201221 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CycleCountFs",
                c => new
                    {
                        CycleCountFId = c.Int(nullable: false, identity: true),
                        CycleCountDateTime = c.DateTime(),
                        CustomerPn = c.String(),
                        SageQty = c.Int(nullable: false),
                        PortalQty = c.Int(nullable: false),
                        ActualQty = c.Int(nullable: false),
                        SageAdjQty = c.Int(nullable: false),
                        PortalAdjQty = c.Int(nullable: false),
                        LocationsCounted = c.String(),
                        CountedBy = c.String(),
                        AuditedBy = c.String(),
                        CountOff = c.String(),
                        CorrectedBy = c.String(),
                        CorrectedDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CycleCountFId);
            
            CreateTable(
                "dbo.FileCycleCounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        CycleCountFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CycleCountFs", t => t.CycleCountFId, cascadeDelete: true)
                .Index(t => t.CycleCountFId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileCycleCounts", "CycleCountFId", "dbo.CycleCountFs");
            DropIndex("dbo.FileCycleCounts", new[] { "CycleCountFId" });
            DropTable("dbo.FileCycleCounts");
            DropTable("dbo.CycleCountFs");
        }
    }
}
