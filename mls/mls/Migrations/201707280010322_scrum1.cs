namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scrum1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scrums", "DepartmentId", c => c.Byte(nullable: false));
            AddColumn("dbo.Scrums", "ClassificationId", c => c.Byte(nullable: false));
            AddColumn("dbo.Scrums", "ScrumStatusId", c => c.Byte(nullable: false));
            DropColumn("dbo.Scrums", "Task");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scrums", "Task", c => c.String());
            DropColumn("dbo.Scrums", "ScrumStatusId");
            DropColumn("dbo.Scrums", "ClassificationId");
            DropColumn("dbo.Scrums", "DepartmentId");
        }
    }
}
