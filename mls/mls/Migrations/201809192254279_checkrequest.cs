namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkrequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckRequests",
                c => new
                    {
                        CheckRequestId = c.Int(nullable: false, identity: true),
                        MlsCo = c.String(),
                        CheckStatus = c.String(),
                        PurchaseOrderNumber = c.String(),
                        PartNumber = c.String(),
                        PartDescription = c.String(),
                        CheckNo = c.String(),
                        Customer = c.String(),
                        Supplier = c.String(),
                        RequestDateTime = c.DateTime(),
                        MailDateTime = c.DateTime(),
                        ActualMailDateTime = c.DateTime(),
                        ShipMethod = c.String(),
                        TrackingInfo = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CheckRequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckRequests");
        }
    }
}
