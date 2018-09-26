namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class etaupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncomingTopLevels", "EtaDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IncomingTopLevels", "EtaDateTime");
        }
    }
}
