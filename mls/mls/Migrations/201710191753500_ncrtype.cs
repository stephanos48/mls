namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncrtype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NcrTypes",
                c => new
                    {
                        NcrTypeId = c.Int(nullable: false, identity: true),
                        NcrTypeName = c.String(),
                    })
                .PrimaryKey(t => t.NcrTypeId);
            
            AddColumn("dbo.NCRs", "NcrTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.NCRs", "NcrType_NcrTypeId", c => c.Int());
            CreateIndex("dbo.NCRs", "NcrType_NcrTypeId");
            AddForeignKey("dbo.NCRs", "NcrType_NcrTypeId", "dbo.NcrTypes", "NcrTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NCRs", "NcrType_NcrTypeId", "dbo.NcrTypes");
            DropIndex("dbo.NCRs", new[] { "NcrType_NcrTypeId" });
            DropColumn("dbo.NCRs", "NcrType_NcrTypeId");
            DropColumn("dbo.NCRs", "NcrTypeId");
            DropTable("dbo.NcrTypes");
        }
    }
}
