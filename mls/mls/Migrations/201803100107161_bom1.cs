namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bom1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BomLevel1", "PurchaseMake", c => c.String());
            AddColumn("dbo.BomLevel1", "PartType", c => c.String());
            AddColumn("dbo.BomLevel1", "PartTypeDetail", c => c.String());
            DropColumn("dbo.BomLevel1", "Qoh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BomLevel1", "Qoh", c => c.Int(nullable: false));
            DropColumn("dbo.BomLevel1", "PartTypeDetail");
            DropColumn("dbo.BomLevel1", "PartType");
            DropColumn("dbo.BomLevel1", "PurchaseMake");
        }
    }
}
