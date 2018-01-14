namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildhistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildHistories",
                c => new
                    {
                        BuildHistoryId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        SerialNo = c.String(),
                        Qty = c.Int(nullable: false),
                        ShipDateTime = c.DateTime(),
                        AssembledBy = c.String(),
                        InspectedBy = c.String(),
                        ShippedBy = c.String(),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.BuildHistoryId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId);
            
            CreateTable(
                "dbo.DownReports",
                c => new
                    {
                        DownReportId = c.Int(nullable: false, identity: true),
                        CreationDateTime = c.DateTime(),
                        CustomerPn = c.String(),
                        QtyNeeded = c.Int(nullable: false),
                        MlsWo = c.String(),
                        CustomerPo = c.String(),
                        EstArrivalDateTime = c.DateTime(),
                        Status = c.String(),
                        Reason = c.String(),
                        Notes = c.String(),
                        MlsDivision_MlsDivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.DownReportId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DownReports", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.BuildHistories", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.BuildHistories", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.BuildHistories", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.DownReports", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.BuildHistories", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.BuildHistories", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.BuildHistories", new[] { "Customer_CustomerId" });
            DropTable("dbo.DownReports");
            DropTable("dbo.BuildHistories");
        }
    }
}
