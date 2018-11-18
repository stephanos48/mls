namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calwk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalWks",
                c => new
                    {
                        CalWkId = c.Int(nullable: false, identity: true),
                        WkYr = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CalWkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalWks");
        }
    }
}
