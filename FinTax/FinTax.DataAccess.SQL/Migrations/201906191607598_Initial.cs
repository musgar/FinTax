namespace FinTax.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COAAttachments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Attachment = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.COALevels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Level = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.COAReportTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ReportType = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        Description = c.String(),
                        Level = c.String(),
                        DownFrom = c.String(),
                        ReportType = c.String(),
                        Attachment = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Coas");
            DropTable("dbo.COAReportTypes");
            DropTable("dbo.COALevels");
            DropTable("dbo.COAAttachments");
        }
    }
}
