namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageupload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Practices",
                c => new
                    {
                        PracticeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PicUrl = c.String(),
                    })
                .PrimaryKey(t => t.PracticeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Practices");
        }
    }
}
