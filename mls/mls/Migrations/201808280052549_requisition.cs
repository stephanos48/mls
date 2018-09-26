namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requisition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requisitions",
                c => new
                    {
                        RequisitionId = c.Int(nullable: false, identity: true),
                        StatusId = c.Byte(nullable: false),
                        Supplier = c.String(),
                        Description = c.String(),
                        PartNumber = c.String(),
                        RequestDate = c.DateTime(),
                        NeedDate = c.DateTime(),
                        EtaDate = c.DateTime(),
                        Requestor = c.String(),
                        Notes = c.String(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.RequisitionId)
                .ForeignKey("dbo.Status", t => t.Status_StatusId)
                .Index(t => t.Status_StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisitions", "Status_StatusId", "dbo.Status");
            DropIndex("dbo.Requisitions", new[] { "Status_StatusId" });
            DropTable("dbo.Requisitions");
        }
    }
}
