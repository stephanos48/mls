namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expfreight : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpFreightDetails",
                c => new
                    {
                        ExpFreightDetailId = c.Int(nullable: false, identity: true),
                        ExpediteMode = c.String(),
                        StartDateTime = c.DateTime(),
                        ArrivalDateTime = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        ExpeditedFreights_ExpeditedFreightId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpFreightDetailId)
                .ForeignKey("dbo.ExpeditedFreights", t => t.ExpeditedFreights_ExpeditedFreightId)
                .Index(t => t.ExpeditedFreights_ExpeditedFreightId);
            
            CreateTable(
                "dbo.ExpeditedFreights",
                c => new
                    {
                        ExpeditedFreightId = c.Int(nullable: false, identity: true),
                        ExpeditedFreightNo = c.String(),
                        PartNumber = c.String(),
                        ExpeditedFreightType = c.String(),
                        RequestedBy = c.String(),
                        RequestDateTime = c.DateTime(),
                        NeedDateTime = c.DateTime(),
                        Destination = c.String(),
                        Reason = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ExpeditedFreightId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpFreightDetails", "ExpeditedFreights_ExpeditedFreightId", "dbo.ExpeditedFreights");
            DropIndex("dbo.ExpFreightDetails", new[] { "ExpeditedFreights_ExpeditedFreightId" });
            DropTable("dbo.ExpeditedFreights");
            DropTable("dbo.ExpFreightDetails");
        }
    }
}
