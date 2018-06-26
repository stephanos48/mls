namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incominginsp01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncomingDetails",
                c => new
                    {
                        IncomingDetailsId = c.Int(nullable: false, identity: true),
                        InspectionDateTime = c.DateTime(),
                        PartNumber = c.String(),
                        InspectionCriteria = c.String(),
                        InspectionType = c.String(),
                        QtyReceived = c.Int(nullable: false),
                        QtyInspected = c.Int(nullable: false),
                        QtyGood = c.Int(nullable: false),
                        QtyBad = c.Int(nullable: false),
                        InspectorName = c.String(),
                        Notes = c.String(),
                        IncomingTopLevel_IncomingTopLevelId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomingDetailsId)
                .ForeignKey("dbo.IncomingTopLevels", t => t.IncomingTopLevel_IncomingTopLevelId)
                .Index(t => t.IncomingTopLevel_IncomingTopLevelId);
            
            CreateTable(
                "dbo.IncomingTopLevels",
                c => new
                    {
                        IncomingTopLevelId = c.Int(nullable: false, identity: true),
                        IncomingVesselNo = c.String(),
                        InspectionDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.IncomingTopLevelId);
            
            CreateTable(
                "dbo.IncomingLists",
                c => new
                    {
                        IncomingListId = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(),
                        EndDateTime = c.DateTime(),
                        PartNumber = c.String(),
                        InspectionPer = c.String(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        InspectionCriteria = c.String(),
                        InspectionType = c.String(),
                        InspStatusId = c.Byte(nullable: false),
                        Notes = c.String(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        InspStatus_InspStatusId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomingListId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.InspStatus", t => t.InspStatus_InspStatusId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.InspStatus_InspStatusId)
                .Index(t => t.MlsDivision_MlsDivisionId);
            
            CreateTable(
                "dbo.InspStatus",
                c => new
                    {
                        InspStatusId = c.Int(nullable: false, identity: true),
                        InspStatusName = c.String(),
                    })
                .PrimaryKey(t => t.InspStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomingLists", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.IncomingLists", "InspStatus_InspStatusId", "dbo.InspStatus");
            DropForeignKey("dbo.IncomingLists", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.IncomingLists", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.IncomingDetails", "IncomingTopLevel_IncomingTopLevelId", "dbo.IncomingTopLevels");
            DropIndex("dbo.IncomingLists", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.IncomingLists", new[] { "InspStatus_InspStatusId" });
            DropIndex("dbo.IncomingLists", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.IncomingLists", new[] { "Customer_CustomerId" });
            DropIndex("dbo.IncomingDetails", new[] { "IncomingTopLevel_IncomingTopLevelId" });
            DropTable("dbo.InspStatus");
            DropTable("dbo.IncomingLists");
            DropTable("dbo.IncomingTopLevels");
            DropTable("dbo.IncomingDetails");
        }
    }
}
