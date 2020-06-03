namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpfeppartdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TxQohs", "PartDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TxQohs", "PartDescription");
        }
    }
}
