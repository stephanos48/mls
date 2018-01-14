namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdby : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScrumCreatedBies",
                c => new
                    {
                        CreatedById = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.CreatedById);
            
            CreateTable(
                "dbo.ScrumResponsibles",
                c => new
                    {
                        ResponsibleId = c.Int(nullable: false, identity: true),
                        Responsible = c.String(),
                    })
                .PrimaryKey(t => t.ResponsibleId);
            
            AddColumn("dbo.Scrums", "CreatedById", c => c.String());
            AddColumn("dbo.Scrums", "ResponsibleId", c => c.String());
            AddColumn("dbo.Scrums", "ScrumCreatedBy_CreatedById", c => c.Int());
            AddColumn("dbo.Scrums", "ScrumResponsible_ResponsibleId", c => c.Int());
            CreateIndex("dbo.Scrums", "ScrumCreatedBy_CreatedById");
            CreateIndex("dbo.Scrums", "ScrumResponsible_ResponsibleId");
            AddForeignKey("dbo.Scrums", "ScrumCreatedBy_CreatedById", "dbo.ScrumCreatedBies", "CreatedById");
            AddForeignKey("dbo.Scrums", "ScrumResponsible_ResponsibleId", "dbo.ScrumResponsibles", "ResponsibleId");
            DropColumn("dbo.Scrums", "CreatedBy");
            DropColumn("dbo.Scrums", "Responsible");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scrums", "Responsible", c => c.String());
            AddColumn("dbo.Scrums", "CreatedBy", c => c.String());
            DropForeignKey("dbo.Scrums", "ScrumResponsible_ResponsibleId", "dbo.ScrumResponsibles");
            DropForeignKey("dbo.Scrums", "ScrumCreatedBy_CreatedById", "dbo.ScrumCreatedBies");
            DropIndex("dbo.Scrums", new[] { "ScrumResponsible_ResponsibleId" });
            DropIndex("dbo.Scrums", new[] { "ScrumCreatedBy_CreatedById" });
            DropColumn("dbo.Scrums", "ScrumResponsible_ResponsibleId");
            DropColumn("dbo.Scrums", "ScrumCreatedBy_CreatedById");
            DropColumn("dbo.Scrums", "ResponsibleId");
            DropColumn("dbo.Scrums", "CreatedById");
            DropTable("dbo.ScrumResponsibles");
            DropTable("dbo.ScrumCreatedBies");
        }
    }
}
