namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mpldecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MasterPartLists", "Weight", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MasterPartLists", "Weight", c => c.Int());
        }
    }
}
