namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateprod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionPlans", "ProdStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionPlans", "ProdStatus");
        }
    }
}
