namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demandwk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommitWks",
                c => new
                    {
                        CommitWkId = c.Int(nullable: false, identity: true),
                        CustomerPn = c.String(),
                        WkYr = c.String(),
                        Qty = c.Int(),
                        LastUpdated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CommitWkId);
            
            CreateTable(
                "dbo.DemandWks",
                c => new
                    {
                        DemandWkId = c.Int(nullable: false, identity: true),
                        CustomerPn = c.String(),
                        WkYr = c.String(),
                        Qty = c.Int(),
                        LastUpdated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DemandWkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DemandWks");
            DropTable("dbo.CommitWks");
        }
    }
}
