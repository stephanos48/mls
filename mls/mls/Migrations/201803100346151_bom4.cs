namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bom4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BomLevel1", "BomNo", c => c.Int(nullable: false));
            AlterColumn("dbo.BomLevel1", "QtyPer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BomLevel1", "QtyPer", c => c.Int());
            AlterColumn("dbo.BomLevel1", "BomNo", c => c.Int());
        }
    }
}
