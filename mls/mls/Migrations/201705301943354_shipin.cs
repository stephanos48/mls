namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipInStatus",
                c => new
                    {
                        ShipInStatusId = c.Int(nullable: false, identity: true),
                        ShipInStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ShipInStatusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShipInStatus");
        }
    }
}
