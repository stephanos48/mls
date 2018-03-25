namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixwodetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WoDetails", "Productive_ProductiveId", "dbo.Productives");
            DropForeignKey("dbo.WoDetails", "WoResponsible_WoResponsibleId", "dbo.WoResponsibles");
            DropIndex("dbo.WoDetails", new[] { "Productive_ProductiveId" });
            DropIndex("dbo.WoDetails", new[] { "WoResponsible_WoResponsibleId" });
            AddColumn("dbo.WoDetails", "WoResponsible", c => c.Byte(nullable: false));
            AddColumn("dbo.WoDetails", "Productive", c => c.Byte(nullable: false));
            DropColumn("dbo.WoDetails", "WoResponsibleId");
            DropColumn("dbo.WoDetails", "ProductiveId");
            DropColumn("dbo.WoDetails", "Productive_ProductiveId");
            DropColumn("dbo.WoDetails", "WoResponsible_WoResponsibleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WoDetails", "WoResponsible_WoResponsibleId", c => c.Int());
            AddColumn("dbo.WoDetails", "Productive_ProductiveId", c => c.Int());
            AddColumn("dbo.WoDetails", "ProductiveId", c => c.Byte(nullable: false));
            AddColumn("dbo.WoDetails", "WoResponsibleId", c => c.Byte(nullable: false));
            DropColumn("dbo.WoDetails", "Productive");
            DropColumn("dbo.WoDetails", "WoResponsible");
            CreateIndex("dbo.WoDetails", "WoResponsible_WoResponsibleId");
            CreateIndex("dbo.WoDetails", "Productive_ProductiveId");
            AddForeignKey("dbo.WoDetails", "WoResponsible_WoResponsibleId", "dbo.WoResponsibles", "WoResponsibleId");
            AddForeignKey("dbo.WoDetails", "Productive_ProductiveId", "dbo.Productives", "ProductiveId");
        }
    }
}
