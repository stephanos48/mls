namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quotesv120181117 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checklists", "DepartmentId", c => c.Byte(nullable: false));
            AddColumn("dbo.Checklists", "ChecklistTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Checklists", "EmployeeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checklists", "EmployeeId");
            DropColumn("dbo.Checklists", "ChecklistTypeId");
            DropColumn("dbo.Checklists", "DepartmentId");
        }
    }
}
