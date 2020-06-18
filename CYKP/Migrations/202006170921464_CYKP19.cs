namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.H_CYKP_LogDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        ModuleID = c.Int(),
                        TypeModeid = c.Int(nullable: false),
                        Documentid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_Name_Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_Document", t => t.Documentid, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_NameModule", t => t.ModuleID)
                .ForeignKey("dbo.H_CYKP_Name_Project", t => t.ProjectId)
                .ForeignKey("dbo.H_CYKP_TypeMode", t => t.TypeModeid, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectId)
                .Index(t => t.ModuleID)
                .Index(t => t.TypeModeid)
                .Index(t => t.Documentid);
            
            CreateTable(
                "dbo.H_CYKP_Document",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.H_CYKP_LogInfo", "Name", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.H_CYKP_LogInfo", "srtName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_LogDocuments", "UserId", "dbo.H_CYKP_Users");
            DropForeignKey("dbo.H_CYKP_LogDocuments", "TypeModeid", "dbo.H_CYKP_TypeMode");
            DropForeignKey("dbo.H_CYKP_LogDocuments", "ProjectId", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_LogDocuments", "ModuleID", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_LogDocuments", "Documentid", "dbo.H_CYKP_Document");
            DropForeignKey("dbo.H_CYKP_LogDocuments", "ClientId", "dbo.H_CYKP_Name_Client");
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "Documentid" });
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "TypeModeid" });
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "ModuleID" });
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "ProjectId" });
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "ClientId" });
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "UserId" });
            AlterColumn("dbo.H_CYKP_LogInfo", "srtName", c => c.String());
            AlterColumn("dbo.H_CYKP_LogInfo", "Name", c => c.String(nullable: false));
            DropTable("dbo.H_CYKP_Document");
            DropTable("dbo.H_CYKP_LogDocuments");
        }
    }
}
