namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinvtransfer20200818 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvTransferLogs", "InventoryTransferId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvTransferLogs", "InventoryTransferId");
        }
    }
}
