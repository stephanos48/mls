namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wkschedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        DemandId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        UseDate = c.DateTime(),
                        DemandQty = c.Int(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DemandId);
            
            CreateTable(
                "dbo.WkSchedules",
                c => new
                    {
                        WkScheduleId = c.Int(nullable: false, identity: true),
                        WorkWk = c.String(),
                        WorkDay = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.WkScheduleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WkSchedules");
            DropTable("dbo.Demands");
        }
    }
}
