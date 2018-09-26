namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expfreightupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpeditedFreights", "StatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExpeditedFreights", "InvoiceNo", c => c.String());
            AddColumn("dbo.ExpeditedFreights", "Status_StatusId", c => c.Int());
            AddColumn("dbo.ExpFreightDetails", "Chargeback", c => c.String());
            CreateIndex("dbo.ExpeditedFreights", "Status_StatusId");
            AddForeignKey("dbo.ExpeditedFreights", "Status_StatusId", "dbo.Status", "StatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpeditedFreights", "Status_StatusId", "dbo.Status");
            DropIndex("dbo.ExpeditedFreights", new[] { "Status_StatusId" });
            DropColumn("dbo.ExpFreightDetails", "Chargeback");
            DropColumn("dbo.ExpeditedFreights", "Status_StatusId");
            DropColumn("dbo.ExpeditedFreights", "InvoiceNo");
            DropColumn("dbo.ExpeditedFreights", "StatusId");
        }
    }
}
