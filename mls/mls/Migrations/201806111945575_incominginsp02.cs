namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incominginsp02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncomingDetails", "SerialNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IncomingDetails", "SerialNumber");
        }
    }
}
