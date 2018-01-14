namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesfdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewWorkOrderViewModels", "StartTime", c => c.String());
            AlterColumn("dbo.NewWorkOrderViewModels", "FinishTime", c => c.String());
            AlterColumn("dbo.WorkOrders", "StartTime", c => c.String());
            AlterColumn("dbo.WorkOrders", "FinishTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "FinishTime", c => c.DateTime());
            AlterColumn("dbo.WorkOrders", "StartTime", c => c.DateTime());
            AlterColumn("dbo.NewWorkOrderViewModels", "FinishTime", c => c.DateTime());
            AlterColumn("dbo.NewWorkOrderViewModels", "StartTime", c => c.DateTime());
        }
    }
}
