namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesexp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpFreightDetails", "ExpeditedFreights_ExpeditedFreightId", "dbo.ExpeditedFreights");
            DropIndex("dbo.ExpFreightDetails", new[] { "ExpeditedFreights_ExpeditedFreightId" });
            RenameColumn(table: "dbo.ExpFreightDetails", name: "ExpeditedFreights_ExpeditedFreightId", newName: "ExpeditedFreightId");
            AlterColumn("dbo.ExpFreightDetails", "ExpeditedFreightId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExpFreightDetails", "ExpeditedFreightId");
            AddForeignKey("dbo.ExpFreightDetails", "ExpeditedFreightId", "dbo.ExpeditedFreights", "ExpeditedFreightId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpFreightDetails", "ExpeditedFreightId", "dbo.ExpeditedFreights");
            DropIndex("dbo.ExpFreightDetails", new[] { "ExpeditedFreightId" });
            AlterColumn("dbo.ExpFreightDetails", "ExpeditedFreightId", c => c.Int());
            RenameColumn(table: "dbo.ExpFreightDetails", name: "ExpeditedFreightId", newName: "ExpeditedFreights_ExpeditedFreightId");
            CreateIndex("dbo.ExpFreightDetails", "ExpeditedFreights_ExpeditedFreightId");
            AddForeignKey("dbo.ExpFreightDetails", "ExpeditedFreights_ExpeditedFreightId", "dbo.ExpeditedFreights", "ExpeditedFreightId");
        }
    }
}
