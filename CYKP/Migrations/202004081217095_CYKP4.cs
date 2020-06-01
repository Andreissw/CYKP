namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_Log", "ProjectId_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_NameModule", "ProjectId_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Log", "ModuleID_Id", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_DateTypes", "ModeId_Id", "dbo.H_CYKP_TypeMode");
            DropIndex("dbo.H_CYKP_DateTypes", new[] { "ModeId_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ProjectId_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ModuleID_Id" });
            DropIndex("dbo.H_CYKP_NameModule", new[] { "ProjectId_Id" });
            RenameColumn(table: "dbo.H_CYKP_Log", name: "TypeDate_Id", newName: "TypeDateId");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "TypeMode_Id", newName: "TypeModeid");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "ClientId_Id", newName: "ClientId");
            RenameColumn(table: "dbo.H_CYKP_Name_Project", name: "ClientId_Id", newName: "ClientId");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "ProjectId_Id", newName: "ProjectId");
            RenameColumn(table: "dbo.H_CYKP_NameModule", name: "ProjectId_Id", newName: "Project_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "ModuleID_Id", newName: "ModuleID");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "StatusProductId_Id", newName: "StatusProductId");
            RenameColumn(table: "dbo.H_CYKP_DateTypes", name: "ModeId_Id", newName: "ModelId");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "UserId_Id", newName: "UserId");
            RenameColumn(table: "dbo.H_CYKP_GridMenu", name: "IdMenuName_Id", newName: "MenuNameId");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_TypeDate_Id", newName: "IX_TypeDateId");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_UserId_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_StatusProductId_Id", newName: "IX_StatusProductId");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_TypeMode_Id", newName: "IX_TypeModeid");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_ClientId_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.H_CYKP_Name_Project", name: "IX_ClientId_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.H_CYKP_GridMenu", name: "IX_IdMenuName_Id", newName: "IX_MenuNameId");
            AddColumn("dbo.H_CYKP_NameModule", "ProjecId", c => c.Int(nullable: false));
            AlterColumn("dbo.H_CYKP_DateTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.H_CYKP_DateTypes", "ModelId", c => c.Int(nullable: true));
            AlterColumn("dbo.H_CYKP_Log", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.H_CYKP_Log", "ModuleID", c => c.Int(nullable: false));
            AlterColumn("dbo.H_CYKP_NameModule", "Project_Id", c => c.Int());
            CreateIndex("dbo.H_CYKP_DateTypes", "ModelId");
            CreateIndex("dbo.H_CYKP_Log", "ProjectId");
            CreateIndex("dbo.H_CYKP_Log", "ModuleID");
            CreateIndex("dbo.H_CYKP_NameModule", "Project_Id");
            AddForeignKey("dbo.H_CYKP_Log", "ProjectId", "dbo.H_CYKP_Name_Project", "Id", cascadeDelete: false);
            AddForeignKey("dbo.H_CYKP_NameModule", "Project_Id", "dbo.H_CYKP_Name_Project", "Id");
            AddForeignKey("dbo.H_CYKP_Log", "ModuleID", "dbo.H_CYKP_NameModule", "Id", cascadeDelete: false);
            AddForeignKey("dbo.H_CYKP_DateTypes", "ModelId", "dbo.H_CYKP_TypeMode", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_DateTypes", "ModelId", "dbo.H_CYKP_TypeMode");
            DropForeignKey("dbo.H_CYKP_Log", "ModuleID", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_NameModule", "Project_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Log", "ProjectId", "dbo.H_CYKP_Name_Project");
            DropIndex("dbo.H_CYKP_NameModule", new[] { "Project_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ModuleID" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ProjectId" });
            DropIndex("dbo.H_CYKP_DateTypes", new[] { "ModelId" });
            AlterColumn("dbo.H_CYKP_NameModule", "Project_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.H_CYKP_Log", "ModuleID", c => c.Int());
            AlterColumn("dbo.H_CYKP_Log", "ProjectId", c => c.Int());
            AlterColumn("dbo.H_CYKP_DateTypes", "ModelId", c => c.Int());
            AlterColumn("dbo.H_CYKP_DateTypes", "Name", c => c.String());
            DropColumn("dbo.H_CYKP_NameModule", "ProjecId");
            RenameIndex(table: "dbo.H_CYKP_GridMenu", name: "IX_MenuNameId", newName: "IX_IdMenuName_Id");
            RenameIndex(table: "dbo.H_CYKP_Name_Project", name: "IX_ClientId", newName: "IX_ClientId_Id");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_ClientId", newName: "IX_ClientId_Id");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_TypeModeid", newName: "IX_TypeMode_Id");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_StatusProductId", newName: "IX_StatusProductId_Id");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_UserId", newName: "IX_UserId_Id");
            RenameIndex(table: "dbo.H_CYKP_Log", name: "IX_TypeDateId", newName: "IX_TypeDate_Id");
            RenameColumn(table: "dbo.H_CYKP_GridMenu", name: "MenuNameId", newName: "IdMenuName_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "UserId", newName: "UserId_Id");
            RenameColumn(table: "dbo.H_CYKP_DateTypes", name: "ModelId", newName: "ModeId_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "StatusProductId", newName: "StatusProductId_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "ModuleID", newName: "ModuleID_Id");
            RenameColumn(table: "dbo.H_CYKP_NameModule", name: "Project_Id", newName: "ProjectId_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "ProjectId", newName: "ProjectId_Id");
            RenameColumn(table: "dbo.H_CYKP_Name_Project", name: "ClientId", newName: "ClientId_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "ClientId", newName: "ClientId_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "TypeModeid", newName: "TypeMode_Id");
            RenameColumn(table: "dbo.H_CYKP_Log", name: "TypeDateId", newName: "TypeDate_Id");
            CreateIndex("dbo.H_CYKP_NameModule", "ProjectId_Id");
            CreateIndex("dbo.H_CYKP_Log", "ModuleID_Id");
            CreateIndex("dbo.H_CYKP_Log", "ProjectId_Id");
            CreateIndex("dbo.H_CYKP_DateTypes", "ModeId_Id");
            AddForeignKey("dbo.H_CYKP_DateTypes", "ModeId_Id", "dbo.H_CYKP_TypeMode", "Id");
            AddForeignKey("dbo.H_CYKP_Log", "ModuleID_Id", "dbo.H_CYKP_NameModule", "Id");
            AddForeignKey("dbo.H_CYKP_NameModule", "ProjectId_Id", "dbo.H_CYKP_Name_Project", "Id", cascadeDelete: true);
            AddForeignKey("dbo.H_CYKP_Log", "ProjectId_Id", "dbo.H_CYKP_Name_Project", "Id");
        }
    }
}
