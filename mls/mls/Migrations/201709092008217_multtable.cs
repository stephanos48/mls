namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierContacts",
                c => new
                    {
                        SupplierContactId = c.Int(nullable: false, identity: true),
                        SupplierContactName = c.String(),
                        SupplierContactTitle = c.String(),
                        SupplierContactCell = c.String(),
                        SupplierContactPhone = c.String(),
                        SupplierContactFax = c.String(),
                        SupplierContactEmail = c.String(),
                        Notes = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierContactId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            AddColumn("dbo.Suppliers", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierContacts", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.SupplierContacts", new[] { "SupplierId" });
            DropColumn("dbo.Suppliers", "Notes");
            DropTable("dbo.SupplierContacts");
        }
    }
}
