namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pfepvm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartTypes",
                c => new
                    {
                        PartTypeId = c.Int(nullable: false, identity: true),
                        PartTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PartTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PartTypes");
        }
    }
}
