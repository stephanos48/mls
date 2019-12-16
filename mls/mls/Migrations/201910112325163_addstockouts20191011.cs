namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstockouts20191011 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartStockOuts",
                c => new
                    {
                        PartStockOutId = c.Int(nullable: false, identity: true),
                        PartStockOutName = c.String(),
                    })
                .PrimaryKey(t => t.PartStockOutId);
            
            AddColumn("dbo.WorkOrders", "PartStockOutId", c => c.Byte(nullable: false));
            AddColumn("dbo.WorkOrders", "PartsNeeded", c => c.String());
            AddColumn("dbo.WorkOrders", "PartStockOutNotes", c => c.String());
            AddColumn("dbo.WorkOrders", "PartStockOut_PartStockOutId", c => c.Int());
            AddColumn("dbo.NewWorkOrderViewModels", "PartStockOutId", c => c.Byte(nullable: false));
            AddColumn("dbo.NewWorkOrderViewModels", "PartsNeeded", c => c.String());
            AddColumn("dbo.NewWorkOrderViewModels", "PartStockOutNotes", c => c.String());
            AddColumn("dbo.NewWorkOrderViewModels", "PartStockOut_PartStockOutId", c => c.Int());
            CreateIndex("dbo.WorkOrders", "PartStockOut_PartStockOutId");
            CreateIndex("dbo.NewWorkOrderViewModels", "PartStockOut_PartStockOutId");
            AddForeignKey("dbo.WorkOrders", "PartStockOut_PartStockOutId", "dbo.PartStockOuts", "PartStockOutId");
            AddForeignKey("dbo.NewWorkOrderViewModels", "PartStockOut_PartStockOutId", "dbo.PartStockOuts", "PartStockOutId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewWorkOrderViewModels", "PartStockOut_PartStockOutId", "dbo.PartStockOuts");
            DropForeignKey("dbo.WorkOrders", "PartStockOut_PartStockOutId", "dbo.PartStockOuts");
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "PartStockOut_PartStockOutId" });
            DropIndex("dbo.WorkOrders", new[] { "PartStockOut_PartStockOutId" });
            DropColumn("dbo.NewWorkOrderViewModels", "PartStockOut_PartStockOutId");
            DropColumn("dbo.NewWorkOrderViewModels", "PartStockOutNotes");
            DropColumn("dbo.NewWorkOrderViewModels", "PartsNeeded");
            DropColumn("dbo.NewWorkOrderViewModels", "PartStockOutId");
            DropColumn("dbo.WorkOrders", "PartStockOut_PartStockOutId");
            DropColumn("dbo.WorkOrders", "PartStockOutNotes");
            DropColumn("dbo.WorkOrders", "PartsNeeded");
            DropColumn("dbo.WorkOrders", "PartStockOutId");
            DropTable("dbo.PartStockOuts");
        }
    }
}
