namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        OrderTypeId = c.Int(nullable: false, identity: true),
                        OrderTypeName = c.String(),
                    })
                .PrimaryKey(t => t.OrderTypeId);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        WorId = c.Int(nullable: false, identity: true),
                        MlsDivisionId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        CustomerPn = c.String(nullable: false),
                        Qty = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        OrderTypeId = c.Byte(nullable: false),
                        Sn = c.String(),
                        CustomerPo = c.String(),
                        MlsSo = c.String(),
                        Notes = c.String(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        OrderType_OrderTypeId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.WorId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderType_OrderTypeId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.OrderType_OrderTypeId)
                .Index(t => t.PartType_PartTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.WorkOrders", "OrderType_OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.WorkOrders", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropIndex("dbo.WorkOrders", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.WorkOrders", new[] { "OrderType_OrderTypeId" });
            DropIndex("dbo.WorkOrders", new[] { "MlsDivision_MlsDivisionId" });
            DropTable("dbo.WorkOrders");
            DropTable("dbo.OrderTypes");
        }
    }
}
