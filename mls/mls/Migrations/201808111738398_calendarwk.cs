namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendarwk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarWks",
                c => new
                    {
                        CalendarWkId = c.Int(nullable: false, identity: true),
                        WkName = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CalendarWkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalendarWks");
        }
    }
}
