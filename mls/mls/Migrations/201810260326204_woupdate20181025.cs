namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woupdate20181025 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContainerPoTrackers",
                c => new
                    {
                        ContainerPoTrackerId = c.Int(nullable: false, identity: true),
                        PartNumber = c.String(nullable: false),
                        PoNumber = c.String(),
                        Date1stDateTime = c.DateTime(),
                        Open1stQty = c.String(),
                        ContainerQty = c.String(),
                    })
                .PrimaryKey(t => t.ContainerPoTrackerId);
            
            AddColumn("dbo.WorkOrders", "ShipDate", c => c.DateTime());
            AddColumn("dbo.WorkOrders", "Parts", c => c.String());
            AddColumn("dbo.WorkOrders", "Equipment", c => c.String());
            AddColumn("dbo.WorkOrders", "Resources", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "Resources");
            DropColumn("dbo.WorkOrders", "Equipment");
            DropColumn("dbo.WorkOrders", "Parts");
            DropColumn("dbo.WorkOrders", "ShipDate");
            DropTable("dbo.ContainerPoTrackers");
        }
    }
}
