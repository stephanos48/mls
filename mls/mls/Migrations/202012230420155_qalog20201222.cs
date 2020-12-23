namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qalog20201222 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileQALogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        QALogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QALogs", t => t.QALogId, cascadeDelete: true)
                .Index(t => t.QALogId);
            
            CreateTable(
                "dbo.QALogs",
                c => new
                    {
                        QALogId = c.Int(nullable: false, identity: true),
                        QACreated = c.DateTime(),
                        QANo = c.String(),
                        QATypeId = c.Byte(nullable: false),
                        PartTypeId = c.Byte(nullable: false),
                        MlsDivisionId = c.Byte(nullable: false),
                        CustomerId = c.Byte(nullable: false),
                        CustomerDivisionId = c.Byte(nullable: false),
                        ProblemFoundId = c.Byte(nullable: false),
                        CustomerPn = c.String(),
                        ProblemDescription = c.String(),
                        ContainmentChina = c.String(),
                        CleanPointChina = c.DateTime(),
                        ContainmentUSA = c.String(),
                        CleanPointUsa = c.DateTime(),
                        NCRNo = c.String(),
                        CQStatusId = c.Byte(nullable: false),
                        CARNo = c.String(),
                        Supplier = c.String(),
                        CustomerCARNo = c.String(),
                        MLSChampion = c.String(),
                        SupplierChampion = c.String(),
                        Notes = c.String(),
                        CQStatus_CQStatusId = c.Int(),
                        Customer_CustomerId = c.Int(),
                        CustomerDivision_CustomerDivisionId = c.Int(),
                        MlsDivision_MlsDivisionId = c.Int(),
                        PartType_PartTypeId = c.Int(),
                        ProblemFound_ProblemFoundId = c.Int(),
                        QAType_QATypeId = c.Int(),
                    })
                .PrimaryKey(t => t.QALogId)
                .ForeignKey("dbo.CQStatus", t => t.CQStatus_CQStatusId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.CustomerDivisions", t => t.CustomerDivision_CustomerDivisionId)
                .ForeignKey("dbo.MlsDivisions", t => t.MlsDivision_MlsDivisionId)
                .ForeignKey("dbo.PartTypes", t => t.PartType_PartTypeId)
                .ForeignKey("dbo.ProblemFounds", t => t.ProblemFound_ProblemFoundId)
                .ForeignKey("dbo.QATypes", t => t.QAType_QATypeId)
                .Index(t => t.CQStatus_CQStatusId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.CustomerDivision_CustomerDivisionId)
                .Index(t => t.MlsDivision_MlsDivisionId)
                .Index(t => t.PartType_PartTypeId)
                .Index(t => t.ProblemFound_ProblemFoundId)
                .Index(t => t.QAType_QATypeId);
            
            CreateTable(
                "dbo.ProblemFounds",
                c => new
                    {
                        ProblemFoundId = c.Int(nullable: false, identity: true),
                        ProblemFoundName = c.String(),
                    })
                .PrimaryKey(t => t.ProblemFoundId);
            
            CreateTable(
                "dbo.QATypes",
                c => new
                    {
                        QATypeId = c.Int(nullable: false, identity: true),
                        QATypeName = c.String(),
                    })
                .PrimaryKey(t => t.QATypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QALogs", "QAType_QATypeId", "dbo.QATypes");
            DropForeignKey("dbo.QALogs", "ProblemFound_ProblemFoundId", "dbo.ProblemFounds");
            DropForeignKey("dbo.QALogs", "PartType_PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.QALogs", "MlsDivision_MlsDivisionId", "dbo.MlsDivisions");
            DropForeignKey("dbo.FileQALogs", "QALogId", "dbo.QALogs");
            DropForeignKey("dbo.QALogs", "CustomerDivision_CustomerDivisionId", "dbo.CustomerDivisions");
            DropForeignKey("dbo.QALogs", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.QALogs", "CQStatus_CQStatusId", "dbo.CQStatus");
            DropIndex("dbo.QALogs", new[] { "QAType_QATypeId" });
            DropIndex("dbo.QALogs", new[] { "ProblemFound_ProblemFoundId" });
            DropIndex("dbo.QALogs", new[] { "PartType_PartTypeId" });
            DropIndex("dbo.QALogs", new[] { "MlsDivision_MlsDivisionId" });
            DropIndex("dbo.QALogs", new[] { "CustomerDivision_CustomerDivisionId" });
            DropIndex("dbo.QALogs", new[] { "Customer_CustomerId" });
            DropIndex("dbo.QALogs", new[] { "CQStatus_CQStatusId" });
            DropIndex("dbo.FileQALogs", new[] { "QALogId" });
            DropTable("dbo.QATypes");
            DropTable("dbo.ProblemFounds");
            DropTable("dbo.QALogs");
            DropTable("dbo.FileQALogs");
        }
    }
}
