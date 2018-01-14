namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scrumup1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScrumCreators",
                c => new
                    {
                        ScrumCreatorId = c.Int(nullable: false, identity: true),
                        ScrumCreatorName = c.String(),
                        ScrumCreatorEmail = c.String(),
                    })
                .PrimaryKey(t => t.ScrumCreatorId);
            
            CreateTable(
                "dbo.ScrumDetails",
                c => new
                    {
                        ScrumDetailId = c.Int(nullable: false, identity: true),
                        ScrumUpdate = c.String(),
                        UpdateDateTime = c.DateTime(),
                        UpdatePerson = c.String(),
                        PriorDueDateTime = c.DateTime(),
                        NewDueDateTime = c.DateTime(),
                        Notes = c.String(),
                        ScrumHeroes_ScrumHeroId = c.Int(),
                    })
                .PrimaryKey(t => t.ScrumDetailId)
                .ForeignKey("dbo.ScrumHeroes", t => t.ScrumHeroes_ScrumHeroId)
                .Index(t => t.ScrumHeroes_ScrumHeroId);
            
            CreateTable(
                "dbo.ScrumHeroes",
                c => new
                    {
                        ScrumHeroId = c.Int(nullable: false, identity: true),
                        ScrumCreatorId = c.String(),
                        CreationDateTime = c.DateTime(),
                        ResponsibleId = c.String(),
                        DepartmentId = c.Byte(nullable: false),
                        Action = c.String(),
                        ClassificationId = c.Byte(nullable: false),
                        ScrumStatusId = c.Byte(nullable: false),
                        DueDateTime = c.DateTime(),
                        CompletionDateTime = c.DateTime(),
                        Notes = c.String(),
                        Classification_ClassificationId = c.Int(),
                        Department_DepartmentId = c.Int(),
                        ScrumCreator_ScrumCreatorId = c.Int(),
                        ScrumResponsible_ResponsibleId = c.Int(),
                        ScrumStatus_ScrumStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ScrumHeroId)
                .ForeignKey("dbo.Classifications", t => t.Classification_ClassificationId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.ScrumCreators", t => t.ScrumCreator_ScrumCreatorId)
                .ForeignKey("dbo.ScrumResponsibles", t => t.ScrumResponsible_ResponsibleId)
                .ForeignKey("dbo.ScrumStatus", t => t.ScrumStatus_ScrumStatusId)
                .Index(t => t.Classification_ClassificationId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.ScrumCreator_ScrumCreatorId)
                .Index(t => t.ScrumResponsible_ResponsibleId)
                .Index(t => t.ScrumStatus_ScrumStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScrumHeroes", "ScrumStatus_ScrumStatusId", "dbo.ScrumStatus");
            DropForeignKey("dbo.ScrumHeroes", "ScrumResponsible_ResponsibleId", "dbo.ScrumResponsibles");
            DropForeignKey("dbo.ScrumDetails", "ScrumHeroes_ScrumHeroId", "dbo.ScrumHeroes");
            DropForeignKey("dbo.ScrumHeroes", "ScrumCreator_ScrumCreatorId", "dbo.ScrumCreators");
            DropForeignKey("dbo.ScrumHeroes", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ScrumHeroes", "Classification_ClassificationId", "dbo.Classifications");
            DropIndex("dbo.ScrumHeroes", new[] { "ScrumStatus_ScrumStatusId" });
            DropIndex("dbo.ScrumHeroes", new[] { "ScrumResponsible_ResponsibleId" });
            DropIndex("dbo.ScrumHeroes", new[] { "ScrumCreator_ScrumCreatorId" });
            DropIndex("dbo.ScrumHeroes", new[] { "Department_DepartmentId" });
            DropIndex("dbo.ScrumHeroes", new[] { "Classification_ClassificationId" });
            DropIndex("dbo.ScrumDetails", new[] { "ScrumHeroes_ScrumHeroId" });
            DropTable("dbo.ScrumHeroes");
            DropTable("dbo.ScrumDetails");
            DropTable("dbo.ScrumCreators");
        }
    }
}
