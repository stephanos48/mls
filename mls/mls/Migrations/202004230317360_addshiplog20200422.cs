namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshiplog20200422 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipPlanLogs",
                c => new
                    {
                        ShipPlanLogId = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        EventDateTime = c.DateTime(),
                        EventType = c.String(),
                        ShipPlanId = c.Int(nullable: false),
                        OrderDateTime = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerOrderNo = c.String(nullable: false),
                        CustomerOrderLine = c.String(),
                        SoNumber = c.String(),
                        WoNumber = c.String(),
                        CustomerPn = c.String(),
                        UhPn = c.String(),
                        PartDescription = c.String(),
                        OrderQty = c.Int(nullable: false),
                        ShipQty = c.Int(),
                        RequestedDateTime = c.DateTime(),
                        PromiseDateTime = c.DateTime(),
                        ShipDateTime = c.DateTime(),
                        ShipPlanStatusId = c.Byte(nullable: false),
                        CQStatusId = c.Byte(nullable: false),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        ShipToAddress = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ShipPlanLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShipPlanLogs");
        }
    }
}
