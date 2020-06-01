namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_Log", "ModuleID", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_Log", "ProjectId", "dbo.H_CYKP_Name_Project");
            DropIndex("dbo.H_CYKP_Log", new[] { "ProjectId" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ModuleID" });
            AlterColumn("dbo.H_CYKP_Log", "ProjectId", c => c.Int());
            AlterColumn("dbo.H_CYKP_Log", "ModuleID", c => c.Int());
            CreateIndex("dbo.H_CYKP_Log", "ProjectId");
            CreateIndex("dbo.H_CYKP_Log", "ModuleID");
            AddForeignKey("dbo.H_CYKP_Log", "ModuleID", "dbo.H_CYKP_NameModule", "Id");
            AddForeignKey("dbo.H_CYKP_Log", "ProjectId", "dbo.H_CYKP_Name_Project", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_Log", "ProjectId", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Log", "ModuleID", "dbo.H_CYKP_NameModule");
            DropIndex("dbo.H_CYKP_Log", new[] { "ModuleID" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ProjectId" });
            AlterColumn("dbo.H_CYKP_Log", "ModuleID", c => c.Int(nullable: false));
            AlterColumn("dbo.H_CYKP_Log", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.H_CYKP_Log", "ModuleID");
            CreateIndex("dbo.H_CYKP_Log", "ProjectId");
            AddForeignKey("dbo.H_CYKP_Log", "ProjectId", "dbo.H_CYKP_Name_Project", "Id", cascadeDelete: true);
            AddForeignKey("dbo.H_CYKP_Log", "ModuleID", "dbo.H_CYKP_NameModule", "Id", cascadeDelete: true);
        }
    }
}
