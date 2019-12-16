namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cyclecount20191013 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CycleCounts",
                c => new
                    {
                        CycleCountId = c.Int(nullable: false, identity: true),
                        CycleCountDateTime = c.DateTime(),
                        CustomerPn = c.String(),
                        SageQty = c.Int(nullable: false),
                        PortalQty = c.Int(nullable: false),
                        ActualQty = c.Int(nullable: false),
                        LocationsCounted = c.String(),
                        CountedBy = c.String(),
                        AuditedBy = c.String(),
                        CountOff = c.String(),
                        CorrectedBy = c.String(),
                        CorrectedDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CycleCountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CycleCounts");
        }
    }
}
