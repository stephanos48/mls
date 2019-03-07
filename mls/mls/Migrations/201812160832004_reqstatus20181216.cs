namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqstatus20181216 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requisitions", "Status_StatusId", "dbo.Status");
            DropIndex("dbo.Requisitions", new[] { "Status_StatusId" });
            CreateTable(
                "dbo.ReqStatus",
                c => new
                    {
                        ReqStatusId = c.Int(nullable: false, identity: true),
                        ReqStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ReqStatusId);
            
            AddColumn("dbo.Requisitions", "ReqStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.Requisitions", "ReqStatus_ReqStatusId", c => c.Int());
            CreateIndex("dbo.Requisitions", "ReqStatus_ReqStatusId");
            AddForeignKey("dbo.Requisitions", "ReqStatus_ReqStatusId", "dbo.ReqStatus", "ReqStatusId");
            DropColumn("dbo.Requisitions", "StatusId");
            DropColumn("dbo.Requisitions", "Status_StatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requisitions", "Status_StatusId", c => c.Int());
            AddColumn("dbo.Requisitions", "StatusId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Requisitions", "ReqStatus_ReqStatusId", "dbo.ReqStatus");
            DropIndex("dbo.Requisitions", new[] { "ReqStatus_ReqStatusId" });
            DropColumn("dbo.Requisitions", "ReqStatus_ReqStatusId");
            DropColumn("dbo.Requisitions", "ReqStatusId");
            DropTable("dbo.ReqStatus");
            CreateIndex("dbo.Requisitions", "Status_StatusId");
            AddForeignKey("dbo.Requisitions", "Status_StatusId", "dbo.Status", "StatusId");
        }
    }
}
