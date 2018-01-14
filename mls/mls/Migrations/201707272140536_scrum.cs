namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scrum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classifications",
                c => new
                    {
                        ClassificationId = c.Int(nullable: false, identity: true),
                        ClassificationName = c.String(),
                    })
                .PrimaryKey(t => t.ClassificationId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Scrums",
                c => new
                    {
                        ScrumId = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreationDateTime = c.DateTime(),
                        Responsible = c.String(),
                        Task = c.String(),
                        Action = c.String(),
                        DueDateTime = c.DateTime(),
                        CompletionDateTime = c.DateTime(),
                        Notes = c.String(),
                        Classification_ClassificationId = c.Int(),
                        Department_DepartmentId = c.Int(),
                        ScrumStatus_ScrumStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ScrumId)
                .ForeignKey("dbo.Classifications", t => t.Classification_ClassificationId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.ScrumStatus", t => t.ScrumStatus_ScrumStatusId)
                .Index(t => t.Classification_ClassificationId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.ScrumStatus_ScrumStatusId);
            
            CreateTable(
                "dbo.ScrumStatus",
                c => new
                    {
                        ScrumStatusId = c.Int(nullable: false, identity: true),
                        ScrumStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ScrumStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scrums", "ScrumStatus_ScrumStatusId", "dbo.ScrumStatus");
            DropForeignKey("dbo.Scrums", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Scrums", "Classification_ClassificationId", "dbo.Classifications");
            DropIndex("dbo.Scrums", new[] { "ScrumStatus_ScrumStatusId" });
            DropIndex("dbo.Scrums", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Scrums", new[] { "Classification_ClassificationId" });
            DropTable("dbo.ScrumStatus");
            DropTable("dbo.Scrums");
            DropTable("dbo.Departments");
            DropTable("dbo.Classifications");
        }
    }
}
