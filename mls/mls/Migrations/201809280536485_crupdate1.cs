namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crupdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requisitions", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requisitions", "Quantity");
        }
    }
}
