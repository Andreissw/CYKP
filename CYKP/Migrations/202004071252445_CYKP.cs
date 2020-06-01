namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.H_CYKP_DateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModeId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_TypeMode", t => t.ModeId_Id)
                .Index(t => t.ModeId_Id);
            
            CreateTable(
                "dbo.H_CYKP_Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        DateFact = c.DateTime(nullable: false),
                        ProjectId_Id = c.Int(),
                        ModuleID_Id = c.Int(),
                        ClientId_Id = c.Int(nullable: false),
                        StatusProductId_Id = c.Int(nullable: false),
                        TypeDate_Id = c.Int(nullable: false),
                        TypeMode_Id = c.Int(nullable: false),
                        UserId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_Name_Project", t => t.ProjectId_Id)
                .ForeignKey("dbo.H_CYKP_NameModule", t => t.ModuleID_Id)
                .ForeignKey("dbo.H_CYKP_Name_Client", t => t.ClientId_Id, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_StatusProduct", t => t.StatusProductId_Id, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_DateTypes", t => t.TypeDate_Id, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_TypeMode", t => t.TypeMode_Id, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_Users", t => t.UserId_Id, cascadeDelete: true)
                .Index(t => t.ProjectId_Id)
                .Index(t => t.ModuleID_Id)
                .Index(t => t.ClientId_Id)
                .Index(t => t.StatusProductId_Id)
                .Index(t => t.TypeDate_Id)
                .Index(t => t.TypeMode_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.H_CYKP_Name_Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(),
                        Contract_Num = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.H_CYKP_Name_Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameProject = c.String(nullable: false),
                        Count = c.String(maxLength: 6),
                        ClientId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_Name_Client", t => t.ClientId_Id, cascadeDelete: true)
                .Index(t => t.ClientId_Id);
            
            CreateTable(
                "dbo.H_CYKP_NameModule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameModule = c.String(nullable: false),
                        CountModule = c.String(maxLength: 6),
                        ProjectId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_Name_Project", t => t.ProjectId_Id, cascadeDelete: true)
                .Index(t => t.ProjectId_Id);
            
            CreateTable(
                "dbo.H_CYKP_StatusProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.H_CYKP_TypeMode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.H_CYKP_Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RFID = c.String(nullable: false, maxLength: 15),
                        UserName = c.String(nullable: false),
                        Status_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_StatusUser", t => t.Status_Id, cascadeDelete: true)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.H_CYKP_StatusUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_Log", "UserId_Id", "dbo.H_CYKP_Users");
            DropForeignKey("dbo.H_CYKP_Users", "Status_Id", "dbo.H_CYKP_StatusUser");
            DropForeignKey("dbo.H_CYKP_Log", "TypeMode_Id", "dbo.H_CYKP_TypeMode");
            DropForeignKey("dbo.H_CYKP_DateTypes", "ModeId_Id", "dbo.H_CYKP_TypeMode");
            DropForeignKey("dbo.H_CYKP_Log", "TypeDate_Id", "dbo.H_CYKP_DateTypes");
            DropForeignKey("dbo.H_CYKP_Log", "StatusProductId_Id", "dbo.H_CYKP_StatusProduct");
            DropForeignKey("dbo.H_CYKP_Log", "ClientId_Id", "dbo.H_CYKP_Name_Client");
            DropForeignKey("dbo.H_CYKP_NameModule", "ProjectId_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Log", "ModuleID_Id", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_Log", "ProjectId_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Name_Project", "ClientId_Id", "dbo.H_CYKP_Name_Client");
            DropIndex("dbo.H_CYKP_Users", new[] { "Status_Id" });
            DropIndex("dbo.H_CYKP_NameModule", new[] { "ProjectId_Id" });
            DropIndex("dbo.H_CYKP_Name_Project", new[] { "ClientId_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "UserId_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "TypeMode_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "TypeDate_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "StatusProductId_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ClientId_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ModuleID_Id" });
            DropIndex("dbo.H_CYKP_Log", new[] { "ProjectId_Id" });
            DropIndex("dbo.H_CYKP_DateTypes", new[] { "ModeId_Id" });
            DropTable("dbo.H_CYKP_StatusUser");
            DropTable("dbo.H_CYKP_Users");
            DropTable("dbo.H_CYKP_TypeMode");
            DropTable("dbo.H_CYKP_StatusProduct");
            DropTable("dbo.H_CYKP_NameModule");
            DropTable("dbo.H_CYKP_Name_Project");
            DropTable("dbo.H_CYKP_Name_Client");
            DropTable("dbo.H_CYKP_Log");
            DropTable("dbo.H_CYKP_DateTypes");
        }
    }
}
