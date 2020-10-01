namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventorytransfer20200816 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileInvDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        InventoryTransferId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InventoryTransfers", t => t.InventoryTransferId, cascadeDelete: true)
                .Index(t => t.InventoryTransferId);
            
            CreateTable(
                "dbo.InventoryTransfers",
                c => new
                    {
                        InventoryTransferId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.InventoryTransferId)
                .ForeignKey("dbo.FinishInvLocations", t => t.FinishInvLocation_FinishInvLocationId)
                .ForeignKey("dbo.InvLocations", t => t.InvLocation_InvLocationId)
                .Index(t => t.FinishInvLocation_FinishInvLocationId)
                .Index(t => t.InvLocation_InvLocationId);
            
            CreateTable(
                "dbo.InvTransferLogs",
                c => new
                    {
                        InvTransferLogId = c.Int(nullable: false, identity: true),
                        TransferDateTime = c.DateTime(),
                        InvLocationId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        PartDescription = c.String(),
                        TransferQty = c.Int(),
                        Notes = c.String(),
                        InvLocation_InvLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.InvTransferLogId)
                .ForeignKey("dbo.InvLocations", t => t.InvLocation_InvLocationId)
                .Index(t => t.InvLocation_InvLocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvTransferLogs", "InvLocation_InvLocationId", "dbo.InvLocations");
            DropForeignKey("dbo.InventoryTransfers", "InvLocation_InvLocationId", "dbo.InvLocations");
            DropForeignKey("dbo.InventoryTransfers", "FinishInvLocation_FinishInvLocationId", "dbo.FinishInvLocations");
            DropForeignKey("dbo.FileInvDetails", "InventoryTransferId", "dbo.InventoryTransfers");
            DropIndex("dbo.InvTransferLogs", new[] { "InvLocation_InvLocationId" });
            DropIndex("dbo.InventoryTransfers", new[] { "InvLocation_InvLocationId" });
            DropIndex("dbo.InventoryTransfers", new[] { "FinishInvLocation_FinishInvLocationId" });
            DropIndex("dbo.FileInvDetails", new[] { "InventoryTransferId" });
            DropTable("dbo.InvTransferLogs");
            DropTable("dbo.InventoryTransfers");
            DropTable("dbo.FileInvDetails");
        }
    }
}
