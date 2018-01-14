namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddetailsvm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewOrderViewModels", "CustomerOrderNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewOrderViewModels", "CustomerOrderNumber", c => c.String());
        }
    }
}
