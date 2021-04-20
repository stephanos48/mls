namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcheckrequestf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckRequestFs",
                c => new
                    {
                        CheckRequestFId = c.Int(nullable: false, identity: true),
                        MlsCo = c.String(),
                        CheckStatusId = c.Byte(nullable: false),
                        PurchaseOrderNumber = c.String(),
                        PartNumber = c.String(),
                        PartDescription = c.String(),
                        CheckNo = c.String(),
                        Amount = c.String(),
                        Customer = c.String(),
                        Supplier = c.String(),
                        RequestDateTime = c.DateTime(),
                        MailDateTime = c.DateTime(),
                        ActualMailDateTime = c.DateTime(),
                        ShipMethod = c.String(),
                        TrackingInfo = c.String(),
                        Notes = c.String(),
                        CheckStatus_CheckStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.CheckRequestFId)
                .ForeignKey("dbo.CheckStatus", t => t.CheckStatus_CheckStatusId)
                .Index(t => t.CheckStatus_CheckStatusId);
            
            CreateTable(
                "dbo.FileCheckRequestFDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        CheckRequestFId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckRequestFs", t => t.CheckRequestFId, cascadeDelete: true)
                .Index(t => t.CheckRequestFId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileCheckRequestFDetails", "CheckRequestFId", "dbo.CheckRequestFs");
            DropForeignKey("dbo.CheckRequestFs", "CheckStatus_CheckStatusId", "dbo.CheckStatus");
            DropIndex("dbo.FileCheckRequestFDetails", new[] { "CheckRequestFId" });
            DropIndex("dbo.CheckRequestFs", new[] { "CheckStatus_CheckStatusId" });
            DropTable("dbo.FileCheckRequestFDetails");
            DropTable("dbo.CheckRequestFs");
        }
    }
}
