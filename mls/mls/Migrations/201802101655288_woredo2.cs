namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woredo2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productives",
                c => new
                    {
                        ProductiveId = c.Int(nullable: false, identity: true),
                        ProductiveType = c.String(),
                    })
                .PrimaryKey(t => t.ProductiveId);
            
            CreateTable(
                "dbo.WoResponsibles",
                c => new
                    {
                        WoResponsibleId = c.Int(nullable: false, identity: true),
                        Responsible = c.String(),
                        WoEmail = c.String(),
                    })
                .PrimaryKey(t => t.WoResponsibleId);
            
            AddColumn("dbo.WoDetails", "WoResponsibleId", c => c.Byte(nullable: false));
            AddColumn("dbo.WoDetails", "ProductiveId", c => c.Byte(nullable: false));
            AddColumn("dbo.WoDetails", "Productive_ProductiveId", c => c.Int());
            AddColumn("dbo.WoDetails", "WoResponsible_WoResponsibleId", c => c.Int());
            CreateIndex("dbo.WoDetails", "Productive_ProductiveId");
            CreateIndex("dbo.WoDetails", "WoResponsible_WoResponsibleId");
            AddForeignKey("dbo.WoDetails", "Productive_ProductiveId", "dbo.Productives", "ProductiveId");
            AddForeignKey("dbo.WoDetails", "WoResponsible_WoResponsibleId", "dbo.WoResponsibles", "WoResponsibleId");
            DropColumn("dbo.WoDetails", "Employee");
            DropColumn("dbo.WoDetails", "Productive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WoDetails", "Productive", c => c.String());
            AddColumn("dbo.WoDetails", "Employee", c => c.String());
            DropForeignKey("dbo.WoDetails", "WoResponsible_WoResponsibleId", "dbo.WoResponsibles");
            DropForeignKey("dbo.WoDetails", "Productive_ProductiveId", "dbo.Productives");
            DropIndex("dbo.WoDetails", new[] { "WoResponsible_WoResponsibleId" });
            DropIndex("dbo.WoDetails", new[] { "Productive_ProductiveId" });
            DropColumn("dbo.WoDetails", "WoResponsible_WoResponsibleId");
            DropColumn("dbo.WoDetails", "Productive_ProductiveId");
            DropColumn("dbo.WoDetails", "ProductiveId");
            DropColumn("dbo.WoDetails", "WoResponsibleId");
            DropTable("dbo.WoResponsibles");
            DropTable("dbo.Productives");
        }
    }
}
