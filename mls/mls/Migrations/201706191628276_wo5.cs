namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wo5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewWorkOrderViewModels", "PartType_PartTypeId", "dbo.PartTypes");
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "PartType_PartTypeId" });
            AddColumn("dbo.NewWorkOrderViewModels", "WoPartTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.NewWorkOrderViewModels", "WoPartType_WoPartTypeId", c => c.Int());
            CreateIndex("dbo.NewWorkOrderViewModels", "WoPartType_WoPartTypeId");
            AddForeignKey("dbo.NewWorkOrderViewModels", "WoPartType_WoPartTypeId", "dbo.WoPartTypes", "WoPartTypeId");
            DropColumn("dbo.NewWorkOrderViewModels", "PartTypeId");
            DropColumn("dbo.NewWorkOrderViewModels", "PartType_PartTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewWorkOrderViewModels", "PartType_PartTypeId", c => c.Int());
            AddColumn("dbo.NewWorkOrderViewModels", "PartTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.NewWorkOrderViewModels", "WoPartType_WoPartTypeId", "dbo.WoPartTypes");
            DropIndex("dbo.NewWorkOrderViewModels", new[] { "WoPartType_WoPartTypeId" });
            DropColumn("dbo.NewWorkOrderViewModels", "WoPartType_WoPartTypeId");
            DropColumn("dbo.NewWorkOrderViewModels", "WoPartTypeId");
            CreateIndex("dbo.NewWorkOrderViewModels", "PartType_PartTypeId");
            AddForeignKey("dbo.NewWorkOrderViewModels", "PartType_PartTypeId", "dbo.PartTypes", "PartTypeId");
        }
    }
}
