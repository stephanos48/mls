namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class choil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChOils",
                c => new
                    {
                        ChOilId = c.Int(nullable: false, identity: true),
                        DateSampleTaken = c.DateTime(),
                        TakenByName = c.String(),
                        Result = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ChOilId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChOils");
        }
    }
}
