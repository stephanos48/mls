namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class containertracker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checklists",
                c => new
                    {
                        ChecklistId = c.Int(nullable: false, identity: true),
                        ChecklistTypeId = c.Byte(nullable: false),
                        EmployeeId = c.Byte(nullable: false),
                        Action = c.String(),
                        Notes = c.String(),
                        ChecklistType_ChecklistTypeId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.ChecklistId)
                .ForeignKey("dbo.ChecklistTypes", t => t.ChecklistType_ChecklistTypeId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.ChecklistType_ChecklistTypeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.ChecklistTypes",
                c => new
                    {
                        ChecklistTypeId = c.Int(nullable: false, identity: true),
                        ChecklistName = c.String(),
                    })
                .PrimaryKey(t => t.ChecklistTypeId);
            
            AddColumn("dbo.ContainerPoTrackers", "ConfirmedDateTime", c => c.DateTime());
            AddColumn("dbo.ContainerPoTrackers", "ContainerNo", c => c.String());
            AddColumn("dbo.ContainerPoTrackers", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checklists", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Checklists", "ChecklistType_ChecklistTypeId", "dbo.ChecklistTypes");
            DropIndex("dbo.Checklists", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Checklists", new[] { "ChecklistType_ChecklistTypeId" });
            DropColumn("dbo.ContainerPoTrackers", "Notes");
            DropColumn("dbo.ContainerPoTrackers", "ContainerNo");
            DropColumn("dbo.ContainerPoTrackers", "ConfirmedDateTime");
            DropTable("dbo.ChecklistTypes");
            DropTable("dbo.Checklists");
        }
    }
}
