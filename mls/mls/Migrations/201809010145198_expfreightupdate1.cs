namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expfreightupdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpeditedFreights", "CustomerId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExpeditedFreights", "CustomerDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExpeditedFreights", "MlsDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.ExpeditedFreights", "ShipDateTime", c => c.DateTime());
            AddColumn("dbo.ExpeditedFreights", "CustomerDivision_CustomerDivisionId", c => c.Int());
            AddColumn("dbo.ExpeditedFreights", "MlsDivision_MlsDivisionId", c => c.Int());
            CreateIndex("dbo.ExpeditedFreights", "CustomerDivision_CustomerDivisionId");
            CreateIndex("dbo.ExpeditedFreights", "MlsDivision_MlsDivisionId");
            AddForeignKey("dbo.ExpeditedFreights", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions", "CustomerDivisionId");
            AddForeignKey("dbo.ExpeditedFreights", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions", "MlsDivisionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpeditedFreights", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.ExpeditedFreights", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropIndex("dbo.ExpeditedFreights", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.ExpeditedFreights", new[] { "CustomerDivision_CustomerDivisionId" });
            DropColumn("dbo.ExpeditedFreights", "MlsDivision_MlsDivisionId");
            DropColumn("dbo.ExpeditedFreights", "CustomerDivision_CustomerDivisionId");
            DropColumn("dbo.ExpeditedFreights", "ShipDateTime");
            DropColumn("dbo.ExpeditedFreights", "MlsDivisionId");
            DropColumn("dbo.ExpeditedFreights", "CustomerDivisionId");
            DropColumn("dbo.ExpeditedFreights", "CustomerId");
        }
    }
}
