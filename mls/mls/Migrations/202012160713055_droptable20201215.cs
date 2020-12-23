namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droptable20201215 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DropTables",
                c => new
                    {
                        DropTableId = c.Byte(nullable: false),
                        Pn = c.String(),
                        Qty = c.Int(nullable: false),
                        hold1 = c.String(),
                        hold2 = c.String(),
                        hold3 = c.String(),
                        hold4 = c.String(),
                        hold5 = c.String(),
                    })
                .PrimaryKey(t => t.DropTableId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DropTables");
        }
    }
}
