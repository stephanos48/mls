namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvTransfer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinishInvLocations",
                c => new
                    {
                        FinishInvLocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.FinishInvLocationId);
            
            CreateTable(
                "dbo.InvLocations",
                c => new
                    {
                        InvLocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.InvLocationId);
            
            CreateTable(
                "dbo.InvTransfers",
                c => new
                    {
                        InvTransferId = c.Int(nullable: false, identity: true),
                        TransferDateTime = c.DateTime(),
                        InvLocationId = c.Byte(nullable: false),
                        FinishInvLocationId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        PartDescription = c.String(),
                        TransferFromQty = c.Int(),
                        TransferToQty = c.Int(),
                        Carrier = c.String(),
                        TrackingInfo = c.String(),
                        ShipToAddress = c.String(),
                        Notes = c.String(),
                        FinishInvLocation_FinishInvLocationId = c.Int(),
                        InvLocation_InvLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.InvTransferId)
                .ForeignKey("dbo.FinishInvLocations", t => t.FinishInvLocation_FinishInvLocationId)
                .ForeignKey("dbo.InvLocations", t => t.InvLocation_InvLocationId)
                .Index(t => t.FinishInvLocation_FinishInvLocationId)
                .Index(t => t.InvLocation_InvLocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvTransfers", "InvLocation_InvLocationId", "dbo.InvLocations");
            DropForeignKey("dbo.InvTransfers", "FinishInvLocation_FinishInvLocationId", "dbo.FinishInvLocations");
            DropIndex("dbo.InvTransfers", new[] { "InvLocation_InvLocationId" });
            DropIndex("dbo.InvTransfers", new[] { "FinishInvLocation_FinishInvLocationId" });
            DropTable("dbo.InvTransfers");
            DropTable("dbo.InvLocations");
            DropTable("dbo.FinishInvLocations");
        }
    }
}
