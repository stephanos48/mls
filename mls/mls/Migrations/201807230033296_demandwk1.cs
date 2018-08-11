namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demandwk1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demands", "DemandWk", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demands", "DemandWk");
        }
    }
}
