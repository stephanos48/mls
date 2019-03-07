namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cordertype20181205 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COrderTypes",
                c => new
                    {
                        COrderTypeId = c.Int(nullable: false, identity: true),
                        COrderTypeName = c.String(),
                    })
                .PrimaryKey(t => t.COrderTypeId);
            
            AddColumn("dbo.CustomerOrders", "COrderTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.CustomerOrders", "COrderType_COrderTypeId", c => c.Int());
            CreateIndex("dbo.CustomerOrders", "COrderType_COrderTypeId");
            AddForeignKey("dbo.CustomerOrders", "COrderType_COrderTypeId", "dbo.COrderTypes", "COrderTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrders", "COrderType_COrderTypeId", "dbo.COrderTypes");
            DropIndex("dbo.CustomerOrders", new[] { "COrderType_COrderTypeId" });
            DropColumn("dbo.CustomerOrders", "COrderType_COrderTypeId");
            DropColumn("dbo.CustomerOrders", "COrderTypeId");
            DropTable("dbo.COrderTypes");
        }
    }
}
