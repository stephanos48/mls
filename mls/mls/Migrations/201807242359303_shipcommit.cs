namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipCommits",
                c => new
                    {
                        ShipCommitId = c.Int(nullable: false, identity: true),
                        Pn = c.String(),
                        ShipCommit30 = c.Int(),
                        ShipCommit31 = c.Int(),
                        ShipCommit32 = c.Int(),
                        ShipCommit33 = c.Int(),
                        ShipCommit34 = c.Int(),
                        ShipCommit35 = c.Int(),
                        ShipCommit36 = c.Int(),
                        ShipCommit37 = c.Int(),
                        ShipCommit38 = c.Int(),
                        ShipCommit39 = c.Int(),
                        ShipCommit40 = c.Int(),
                        ShipCommit41 = c.Int(),
                        ShipCommit42 = c.Int(),
                        ShipCommit43 = c.Int(),
                        ShipCommit44 = c.Int(),
                        ShipCommit45 = c.Int(),
                        ShipCommit46 = c.Int(),
                        ShipCommit47 = c.Int(),
                        ShipCommit48 = c.Int(),
                        ShipCommit49 = c.Int(),
                        ShipCommit50 = c.Int(),
                        ShipCommit51 = c.Int(),
                        ShipCommit52 = c.Int(),
                        ShipCommit1 = c.Int(),
                        ShipCommit2 = c.Int(),
                        ShipCommit3 = c.Int(),
                        ShipCommit4 = c.Int(),
                        ShipCommit5 = c.Int(),
                        ShipCommit6 = c.Int(),
                        ShipCommit7 = c.Int(),
                        ShipCommit8 = c.Int(),
                        ShipCommit9 = c.Int(),
                        ShipCommit10 = c.Int(),
                        ShipCommit11 = c.Int(),
                        ShipCommit12 = c.Int(),
                        ShipCommit13 = c.Int(),
                        ShipCommit14 = c.Int(),
                        ShipCommit15 = c.Int(),
                        ShipCommit16 = c.Int(),
                        ShipCommit17 = c.Int(),
                        ShipCommit18 = c.Int(),
                        ShipCommit19 = c.Int(),
                        ShipCommit20 = c.Int(),
                        ShipCommit21 = c.Int(),
                        ShipCommit22 = c.Int(),
                        ShipCommit23 = c.Int(),
                        ShipCommit24 = c.Int(),
                        ShipCommit25 = c.Int(),
                        ShipCommit26 = c.Int(),
                        ShipCommit27 = c.Int(),
                        ShipCommit28 = c.Int(),
                        ShipCommit29 = c.Int(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ShipCommitId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShipCommits");
        }
    }
}
