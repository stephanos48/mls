namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scrumup2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScrumHeroes", "Classification_ClassificationId", "dbo.Classifications");
            DropForeignKey("dbo.ScrumHeroes", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ScrumHeroes", "ScrumCreator_ScrumCreatorId", "dbo.ScrumCreators");
            DropForeignKey("dbo.ScrumDetails", "ScrumHeroes_ScrumHeroId", "dbo.ScrumHeroes");
            DropForeignKey("dbo.ScrumHeroes", "ScrumResponsible_ResponsibleId", "dbo.ScrumResponsibles");
            DropForeignKey("dbo.ScrumHeroes", "ScrumStatus_ScrumStatusId", "dbo.ScrumStatus");
            DropIndex("dbo.ScrumDetails", new[] { "ScrumHeroes_ScrumHeroId" });
            DropIndex("dbo.ScrumHeroes", new[] { "Classification_ClassificationId" });
            DropIndex("dbo.ScrumHeroes", new[] { "Department_DepartmentId" });
            DropIndex("dbo.ScrumHeroes", new[] { "ScrumCreator_ScrumCreatorId" });
            DropIndex("dbo.ScrumHeroes", new[] { "ScrumResponsible_ResponsibleId" });
            DropIndex("dbo.ScrumHeroes", new[] { "ScrumStatus_ScrumStatusId" });
            AddColumn("dbo.ScrumDetails", "ScrumId", c => c.Int(nullable: false));
            CreateIndex("dbo.ScrumDetails", "ScrumId");
            AddForeignKey("dbo.ScrumDetails", "ScrumId", "dbo.Scrums", "ScrumId", cascadeDelete: true);
            DropColumn("dbo.ScrumDetails", "ScrumHeroes_ScrumHeroId");
            DropTable("dbo.ScrumCreators");
            DropTable("dbo.ScrumHeroes");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ScrumHeroId);
            
            CreateTable(
                "dbo.ScrumCreators",
                c => new
                    {
                        ScrumCreatorId = c.Int(nullable: false, identity: true),
                        ScrumCreatorName = c.String(),
                        ScrumCreatorEmail = c.String(),
                    })
                .PrimaryKey(t => t.ScrumCreatorId);
            
            AddColumn("dbo.ScrumDetails", "ScrumHeroes_ScrumHeroId", c => c.Int());
            DropForeignKey("dbo.ScrumDetails", "ScrumId", "dbo.Scrums");
            DropIndex("dbo.ScrumDetails", new[] { "ScrumId" });
            DropColumn("dbo.ScrumDetails", "ScrumId");
            CreateIndex("dbo.ScrumHeroes", "ScrumStatus_ScrumStatusId");
            CreateIndex("dbo.ScrumHeroes", "ScrumResponsible_ResponsibleId");
            CreateIndex("dbo.ScrumHeroes", "ScrumCreator_ScrumCreatorId");
            CreateIndex("dbo.ScrumHeroes", "Department_DepartmentId");
            CreateIndex("dbo.ScrumHeroes", "Classification_ClassificationId");
            CreateIndex("dbo.ScrumDetails", "ScrumHeroes_ScrumHeroId");
            AddForeignKey("dbo.ScrumHeroes", "ScrumStatus_ScrumStatusId", "dbo.ScrumStatus", "ScrumStatusId");
            AddForeignKey("dbo.ScrumHeroes", "ScrumResponsible_ResponsibleId", "dbo.ScrumResponsibles", "ResponsibleId");
            AddForeignKey("dbo.ScrumDetails", "ScrumHeroes_ScrumHeroId", "dbo.ScrumHeroes", "ScrumHeroId");
            AddForeignKey("dbo.ScrumHeroes", "ScrumCreator_ScrumCreatorId", "dbo.ScrumCreators", "ScrumCreatorId");
            AddForeignKey("dbo.ScrumHeroes", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.ScrumHeroes", "Classification_ClassificationId", "dbo.Classifications", "ClassificationId");
        }
    }
}
