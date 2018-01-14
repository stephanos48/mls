namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewOrderViewModels", "PartDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewOrderViewModels", "PartDescription");
        }
    }
}
