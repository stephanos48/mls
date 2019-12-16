namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqchanges20190919 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PoPlans", "PoSentDateTime", c => c.DateTime());
            AddColumn("dbo.PoPlans", "PoSentBy", c => c.String());
            AddColumn("dbo.PoPlans", "PoConfirmedDateTime", c => c.DateTime());
            AddColumn("dbo.PoPlans", "PoConfirmedBy", c => c.String());
            AddColumn("dbo.Requisitions", "MlsDivisionId", c => c.Byte(nullable: false));
            AddColumn("dbo.Requisitions", "MlsDivision_MlsDivisionId", c => c.Int());
            CreateIndex("dbo.Requisitions", "MlsDivision_MlsDivisionId");
            AddForeignKey("dbo.Requisitions", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions", "MlsDivisionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requisitions", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropIndex("dbo.Requisitions", new[] { "MlsDivision_MlsDivisionId" });
            DropColumn("dbo.Requisitions", "MlsDivision_MlsDivisionId");
            DropColumn("dbo.Requisitions", "MlsDivisionId");
            DropColumn("dbo.PoPlans", "PoConfirmedBy");
            DropColumn("dbo.PoPlans", "PoConfirmedDateTime");
            DropColumn("dbo.PoPlans", "PoSentBy");
            DropColumn("dbo.PoPlans", "PoSentDateTime");
        }
    }
}
