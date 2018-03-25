namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewWorkOrderViewModels", "NeedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewWorkOrderViewModels", "NeedDate");
        }
    }
}
