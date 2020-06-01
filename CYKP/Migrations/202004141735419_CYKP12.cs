namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_NameModule", "Project_Id", "dbo.H_CYKP_Name_Project");
            DropIndex("dbo.H_CYKP_NameModule", new[] { "Project_Id" });
            RenameColumn(table: "dbo.H_CYKP_NameModule", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.H_CYKP_NameModule", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.H_CYKP_NameModule", "ProjectId");
            AddForeignKey("dbo.H_CYKP_NameModule", "ProjectId", "dbo.H_CYKP_Name_Project", "Id", cascadeDelete: true);
            DropColumn("dbo.H_CYKP_NameModule", "ProjecId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.H_CYKP_NameModule", "ProjecId", c => c.Int(nullable: false));
            DropForeignKey("dbo.H_CYKP_NameModule", "ProjectId", "dbo.H_CYKP_Name_Project");
            DropIndex("dbo.H_CYKP_NameModule", new[] { "ProjectId" });
            AlterColumn("dbo.H_CYKP_NameModule", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.H_CYKP_NameModule", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.H_CYKP_NameModule", "Project_Id");
            AddForeignKey("dbo.H_CYKP_NameModule", "Project_Id", "dbo.H_CYKP_Name_Project", "Id");
        }
    }
}
