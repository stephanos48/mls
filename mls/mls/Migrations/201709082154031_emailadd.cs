namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterPartLists", "HtsCode", c => c.String());
            AddColumn("dbo.ScrumCreatedBies", "Email", c => c.String());
            AddColumn("dbo.ScrumResponsibles", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScrumResponsibles", "Email");
            DropColumn("dbo.ScrumCreatedBies", "Email");
            DropColumn("dbo.MasterPartLists", "HtsCode");
        }
    }
}
