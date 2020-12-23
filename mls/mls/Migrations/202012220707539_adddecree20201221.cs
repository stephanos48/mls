namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddecree20201221 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DecreeLogs",
                c => new
                    {
                        DecreeLogId = c.Int(nullable: false, identity: true),
                        DecreeDateTime = c.DateTime(),
                        Decree = c.String(),
                        EffectiveDateTime = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DecreeLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DecreeLogs");
        }
    }
}
