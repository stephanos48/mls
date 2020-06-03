namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipandloginlogadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginLogs",
                c => new
                    {
                        LoginLogId = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        EventDateTime = c.DateTime(),
                        EventType = c.String(),
                    })
                .PrimaryKey(t => t.LoginLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginLogs");
        }
    }
}
