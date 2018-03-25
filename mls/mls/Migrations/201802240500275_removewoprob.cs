namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removewoprob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WoDetails", "TotalTime", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WoDetails", "TotalTime", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
