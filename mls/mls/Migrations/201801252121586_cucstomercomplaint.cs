namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cucstomercomplaint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintTypes",
                c => new
                    {
                        ComplaintTypeId = c.Int(nullable: false, identity: true),
                        ComplaintTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ComplaintTypeId);
            
            CreateTable(
                "dbo.ComplaintSeverities",
                c => new
                    {
                        ComplaintSeverityId = c.Int(nullable: false, identity: true),
                        ComplaintSeverityName = c.String(),
                    })
                .PrimaryKey(t => t.ComplaintSeverityId);
            
            CreateTable(
                "dbo.CustomerComplaints",
                c => new
                    {
                        CustomerComplaintId = c.Int(nullable: false, identity: true),
                        ComplaintDate = c.DateTime(),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        ComplaintSeverityId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        ComplaintTypeId = c.String(),
                        CommplaintDetail = c.String(),
                        StatusId = c.Byte(nullable: false),
                        Notes = c.String(),
                        ComplaintSeverity_ComplaintSeverityId = c.Int(),
                        ComplaintType_ComplaintTypeId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        Status_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerComplaintId)
                .ForeignKey("dbo.ComplaintSeverities", t => t.ComplaintSeverity_ComplaintSeverityId)
                .ForeignKey("dbo.ComplaintTypes", t => t.ComplaintType_ComplaintTypeId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.Status", t => t.Status_StatusId)
                .Index(t => t.ComplaintSeverity_ComplaintSeverityId)
                .Index(t => t.ComplaintType_ComplaintTypeId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.Status_StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerComplaints", "Status_StatusId", "dbo.Status");
            DropForeignKey("dbo.CustomerComplaints", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.CustomerComplaints", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.CustomerComplaints", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerComplaints", "ComplaintType_ComplaintTypeId", "dbo.ComplaintTypes");
            DropForeignKey("dbo.CustomerComplaints", "ComplaintSeverity_ComplaintSeverityId", "dbo.ComplaintSeverities");
            DropIndex("dbo.CustomerComplaints", new[] { "Status_StatusId" });
            DropIndex("dbo.CustomerComplaints", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.CustomerComplaints", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.CustomerComplaints", new[] { "Customer_CustomerId" });
            DropIndex("dbo.CustomerComplaints", new[] { "ComplaintType_ComplaintTypeId" });
            DropIndex("dbo.CustomerComplaints", new[] { "ComplaintSeverity_ComplaintSeverityId" });
            DropTable("dbo.CustomerComplaints");
            DropTable("dbo.ComplaintSeverities");
            DropTable("dbo.ComplaintTypes");
        }
    }
}
