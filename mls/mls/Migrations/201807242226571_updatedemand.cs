namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedemand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demands", "PastDue", c => c.Int());
            AddColumn("dbo.Demands", "OpenPoQty", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk30", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk31", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk32", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk33", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk34", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk35", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk36", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk37", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk38", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk39", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk40", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk41", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk42", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk43", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk44", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk45", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk46", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk47", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk48", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk49", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk50", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk51", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk52", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk1", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk2", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk3", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk4", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk5", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk6", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk7", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk8", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk9", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk10", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk11", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk12", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk13", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk14", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk15", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk16", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk17", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk18", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk19", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk20", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk21", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk22", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk23", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk24", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk25", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk26", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk27", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk28", c => c.Int());
            AddColumn("dbo.Demands", "DemandWk29", c => c.Int());
            DropColumn("dbo.Demands", "DemandQty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demands", "DemandQty", c => c.Int());
            DropColumn("dbo.Demands", "DemandWk29");
            DropColumn("dbo.Demands", "DemandWk28");
            DropColumn("dbo.Demands", "DemandWk27");
            DropColumn("dbo.Demands", "DemandWk26");
            DropColumn("dbo.Demands", "DemandWk25");
            DropColumn("dbo.Demands", "DemandWk24");
            DropColumn("dbo.Demands", "DemandWk23");
            DropColumn("dbo.Demands", "DemandWk22");
            DropColumn("dbo.Demands", "DemandWk21");
            DropColumn("dbo.Demands", "DemandWk20");
            DropColumn("dbo.Demands", "DemandWk19");
            DropColumn("dbo.Demands", "DemandWk18");
            DropColumn("dbo.Demands", "DemandWk17");
            DropColumn("dbo.Demands", "DemandWk16");
            DropColumn("dbo.Demands", "DemandWk15");
            DropColumn("dbo.Demands", "DemandWk14");
            DropColumn("dbo.Demands", "DemandWk13");
            DropColumn("dbo.Demands", "DemandWk12");
            DropColumn("dbo.Demands", "DemandWk11");
            DropColumn("dbo.Demands", "DemandWk10");
            DropColumn("dbo.Demands", "DemandWk9");
            DropColumn("dbo.Demands", "DemandWk8");
            DropColumn("dbo.Demands", "DemandWk7");
            DropColumn("dbo.Demands", "DemandWk6");
            DropColumn("dbo.Demands", "DemandWk5");
            DropColumn("dbo.Demands", "DemandWk4");
            DropColumn("dbo.Demands", "DemandWk3");
            DropColumn("dbo.Demands", "DemandWk2");
            DropColumn("dbo.Demands", "DemandWk1");
            DropColumn("dbo.Demands", "DemandWk52");
            DropColumn("dbo.Demands", "DemandWk51");
            DropColumn("dbo.Demands", "DemandWk50");
            DropColumn("dbo.Demands", "DemandWk49");
            DropColumn("dbo.Demands", "DemandWk48");
            DropColumn("dbo.Demands", "DemandWk47");
            DropColumn("dbo.Demands", "DemandWk46");
            DropColumn("dbo.Demands", "DemandWk45");
            DropColumn("dbo.Demands", "DemandWk44");
            DropColumn("dbo.Demands", "DemandWk43");
            DropColumn("dbo.Demands", "DemandWk42");
            DropColumn("dbo.Demands", "DemandWk41");
            DropColumn("dbo.Demands", "DemandWk40");
            DropColumn("dbo.Demands", "DemandWk39");
            DropColumn("dbo.Demands", "DemandWk38");
            DropColumn("dbo.Demands", "DemandWk37");
            DropColumn("dbo.Demands", "DemandWk36");
            DropColumn("dbo.Demands", "DemandWk35");
            DropColumn("dbo.Demands", "DemandWk34");
            DropColumn("dbo.Demands", "DemandWk33");
            DropColumn("dbo.Demands", "DemandWk32");
            DropColumn("dbo.Demands", "DemandWk31");
            DropColumn("dbo.Demands", "DemandWk30");
            DropColumn("dbo.Demands", "OpenPoQty");
            DropColumn("dbo.Demands", "PastDue");
        }
    }
}
