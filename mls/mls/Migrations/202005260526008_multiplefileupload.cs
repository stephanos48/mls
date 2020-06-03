namespace mls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multiplefileupload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        FileUploadId = c.String(nullable: false, maxLength: 128),
                        FileName = c.String(),
                        FileUrl = c.String(),
                    })
                .PrimaryKey(t => t.FileUploadId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploads");
        }
    }
}
