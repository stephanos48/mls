namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontractor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorId = c.Int(nullable: false, identity: true),
                        ContractorName = c.String(),
                    })
                .PrimaryKey(t => t.ContractorId);
            
            AddColumn("dbo.WorkOrders", "ContractorId", c => c.Byte(nullable: false));
            AddColumn("dbo.WorkOrders", "Contractor_ContractorId", c => c.Int());
            CreateIndex("dbo.WorkOrders", "Contractor_ContractorId");
            AddForeignKey("dbo.WorkOrders", "Contractor_ContractorId", "dbo.Contractors", "ContractorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "Contractor_ContractorId", "dbo.Contractors");
            DropIndex("dbo.WorkOrders", new[] { "Contractor_ContractorId" });
            DropColumn("dbo.WorkOrders", "Contractor_ContractorId");
            DropColumn("dbo.WorkOrders", "ContractorId");
            DropTable("dbo.Contractors");
        }
    }
}
