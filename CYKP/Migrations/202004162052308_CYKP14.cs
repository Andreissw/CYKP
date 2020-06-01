namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.H_CYKP_Date", "client_Id", c => c.Int());
            AddColumn("dbo.H_CYKP_Date", "module_Id", c => c.Int());
            AddColumn("dbo.H_CYKP_Date", "project_Id", c => c.Int());
            CreateIndex("dbo.H_CYKP_Date", "client_Id");
            CreateIndex("dbo.H_CYKP_Date", "module_Id");
            CreateIndex("dbo.H_CYKP_Date", "project_Id");
            AddForeignKey("dbo.H_CYKP_Date", "client_Id", "dbo.H_CYKP_Name_Client", "Id");
            AddForeignKey("dbo.H_CYKP_Date", "module_Id", "dbo.H_CYKP_NameModule", "Id");
            AddForeignKey("dbo.H_CYKP_Date", "project_Id", "dbo.H_CYKP_Name_Project", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_Date", "project_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Date", "module_Id", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_Date", "client_Id", "dbo.H_CYKP_Name_Client");
            DropIndex("dbo.H_CYKP_Date", new[] { "project_Id" });
            DropIndex("dbo.H_CYKP_Date", new[] { "module_Id" });
            DropIndex("dbo.H_CYKP_Date", new[] { "client_Id" });
            DropColumn("dbo.H_CYKP_Date", "project_Id");
            DropColumn("dbo.H_CYKP_Date", "module_Id");
            DropColumn("dbo.H_CYKP_Date", "client_Id");
        }
    }
}
