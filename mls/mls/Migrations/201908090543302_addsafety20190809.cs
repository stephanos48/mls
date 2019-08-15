namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsafety20190809 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SafetyIncidents",
                c => new
                    {
                        SafetyIncidentId = c.Int(nullable: false, identity: true),
                        IncidentDate = c.DateTime(),
                        IncidentDetails = c.String(),
                        Employee = c.String(),
                        IncidentType = c.String(),
                        CorrectieAction = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.SafetyIncidentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SafetyIncidents");
        }
    }
}
