namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.H_CYKP_LogInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        srtName = c.String(nullable: true),
                        Count = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.H_CYKP_Log", "LogInfoID", c => c.Int(nullable: false));
            CreateIndex("dbo.H_CYKP_Log", "LogInfoID");
            AddForeignKey("dbo.H_CYKP_Log", "LogInfoID", "dbo.H_CYKP_LogInfo", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_Log", "LogInfoID", "dbo.H_CYKP_LogInfo");
            DropIndex("dbo.H_CYKP_Log", new[] { "LogInfoID" });
            DropColumn("dbo.H_CYKP_Log", "LogInfoID");
            DropTable("dbo.H_CYKP_LogInfo");
        }
    }
}
