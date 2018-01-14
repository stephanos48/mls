namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterPartLists", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MasterPartLists", "Location");
        }
    }
}
