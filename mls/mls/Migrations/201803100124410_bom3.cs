namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bom3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BomLevel1", "QtyPer", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BomLevel1", "QtyPer", c => c.Int(nullable: false));
        }
    }
}
