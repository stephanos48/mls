namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MasterPartLists", "Weight", c => c.Int());
            AlterColumn("dbo.MasterPartLists", "StdPack", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MasterPartLists", "StdPack", c => c.Int(nullable: false));
            AlterColumn("dbo.MasterPartLists", "Weight", c => c.Int(nullable: false));
        }
    }
}
