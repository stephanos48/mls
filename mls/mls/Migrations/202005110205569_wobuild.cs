namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wobuild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WoBuilds",
                c => new
                    {
                        WoBuildId = c.Int(nullable: false, identity: true),
                        WoEnterDateTime = c.DateTime(),
                        WoNo = c.String(),
                        CustomerPn = c.String(),
                        Qty = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.WoBuildId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WoBuilds");
        }
    }
}
