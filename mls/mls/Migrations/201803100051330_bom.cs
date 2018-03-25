namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BomLevel1",
                c => new
                    {
                        BomLevel1Id = c.Int(nullable: false, identity: true),
                        BomNo = c.Int(nullable: false),
                        UnitNo = c.String(),
                        DetailPn = c.String(),
                        Description = c.String(),
                        QtyPer = c.Int(nullable: false),
                        Qoh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BomLevel1Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BomLevel1");
        }
    }
}
