namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quote20181116 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotes", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Quotes", new[] { "SupplierId" });
            AddColumn("dbo.Quotes", "Supplier_SupplierId", c => c.Int());
            AlterColumn("dbo.Quotes", "SupplierId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Quotes", "Supplier_SupplierId");
            AddForeignKey("dbo.Quotes", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "Supplier_SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Quotes", new[] { "Supplier_SupplierId" });
            AlterColumn("dbo.Quotes", "SupplierId", c => c.Int(nullable: false));
            DropColumn("dbo.Quotes", "Supplier_SupplierId");
            CreateIndex("dbo.Quotes", "SupplierId");
            AddForeignKey("dbo.Quotes", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
    }
}
