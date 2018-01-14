namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pfep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pfeps",
                c => new
                    {
                        PfepId = c.Int(nullable: false, identity: true),
                        CustomerPn = c.String(nullable: false),
                        PartType = c.String(),
                        LtCustomer = c.Int(),
                        LtTx = c.Int(),
                        LtOcean = c.Int(),
                        LtHaimen = c.Int(),
                        LtAssy = c.Int(),
                        PfepCustomer = c.Int(),
                        PfepTx = c.Int(),
                        PfepOcean = c.Int(),
                        PfepHaimen = c.Int(),
                        PfepAssy = c.Int(),
                        Min = c.Int(),
                        Max = c.Int(),
                        KbQty = c.Int(),
                    })
                .PrimaryKey(t => t.PfepId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pfeps");
        }
    }
}
