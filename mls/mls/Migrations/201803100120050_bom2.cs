namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bom2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BomLevel1", "BomNo", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BomLevel1", "BomNo", c => c.Int(nullable: false));
        }
    }
}
