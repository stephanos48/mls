namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeSageId = c.String(),
                        EmployeeFirstName = c.String(),
                        EmployeeMiddleName = c.String(),
                        EmployeeLastName = c.String(),
                        EmployeeTitle = c.String(),
                        DepartmentId = c.Byte(nullable: false),
                        EmployeeEmail = c.String(),
                        EmployeeCell = c.String(),
                        EmployeeAddress = c.String(),
                        EmployeeCity = c.String(),
                        EmployeeState = c.String(),
                        EmployeeZip = c.String(),
                        EmployeeCountry = c.String(),
                        EmployeeNotes = c.String(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropTable("dbo.Employees");
        }
    }
}
