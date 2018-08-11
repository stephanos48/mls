namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promisedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "PromiseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "PromiseDate");
        }
    }
}
