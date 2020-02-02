namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixreqopen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requisitions", "CloseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requisitions", "CloseDate");
        }
    }
}
