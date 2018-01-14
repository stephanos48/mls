namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsotopartial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewOrderViewModels", "SoNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewOrderViewModels", "SoNumber");
        }
    }
}
