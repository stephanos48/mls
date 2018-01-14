namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pfeps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TxQohs",
                c => new
                    {
                        Txqohid = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        UhPn = c.String(),
                        Qoh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Txqohid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TxQohs");
        }
    }
}
