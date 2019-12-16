namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshiphot20191013 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipPlans", "CQStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.ShipPlans", "CQStatus_CQStatusId", c => c.Int());
            CreateIndex("dbo.ShipPlans", "CQStatus_CQStatusId");
            AddForeignKey("dbo.ShipPlans", "CQStatus_CQStatusId", "dbo.CQStatus", "CQStatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipPlans", "CQStatus_CQStatusId", "dbo.CQStatus");
            DropIndex("dbo.ShipPlans", new[] { "CQStatus_CQStatusId" });
            DropColumn("dbo.ShipPlans", "CQStatus_CQStatusId");
            DropColumn("dbo.ShipPlans", "CQStatusId");
        }
    }
}
