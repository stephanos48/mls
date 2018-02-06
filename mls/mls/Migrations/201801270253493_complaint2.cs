namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complaint2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerComplaints", "ComplaintTypeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerComplaints", "ComplaintTypeId", c => c.String());
        }
    }
}
