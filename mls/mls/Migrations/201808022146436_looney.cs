namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class looney : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewWorkOrderViewModels", "PromiseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewWorkOrderViewModels", "PromiseDate");
        }
    }
}
