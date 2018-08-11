namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerqoh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerQohs",
                c => new
                    {
                        CustomerQohId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        UhPn = c.String(),
                        Qoh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerQohId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerQohs");
        }
    }
}
