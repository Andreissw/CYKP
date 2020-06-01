namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_Date", "client_Id", "dbo.H_CYKP_Name_Client");
            DropForeignKey("dbo.H_CYKP_Date", "module_Id", "dbo.H_CYKP_NameModule");
            DropForeignKey("dbo.H_CYKP_Date", "project_Id", "dbo.H_CYKP_Name_Project");
            DropForeignKey("dbo.H_CYKP_Date", "TypeModeID", "dbo.H_CYKP_TypeMode");
            DropForeignKey("dbo.H_CYKP_Date", "DateTypeID", "dbo.H_CYKP_DateTypes");
            DropIndex("dbo.H_CYKP_Date", new[] { "TypeModeID" });
            DropIndex("dbo.H_CYKP_Date", new[] { "DateTypeID" });
            DropIndex("dbo.H_CYKP_Date", new[] { "client_Id" });
            DropIndex("dbo.H_CYKP_Date", new[] { "module_Id" });
            DropIndex("dbo.H_CYKP_Date", new[] { "project_Id" });
            AddColumn("dbo.H_CYKP_Log", "DateTypeID", c => c.Int());
            CreateIndex("dbo.H_CYKP_Log", "DateTypeID");
            AddForeignKey("dbo.H_CYKP_Log", "DateTypeID", "dbo.H_CYKP_DateTypes", "Id");
            DropTable("dbo.H_CYKP_Date");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.H_CYKP_Date",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TypeModeID = c.Int(nullable: false),
                        DateTypeID = c.Int(nullable: false),
                        NameID = c.Int(nullable: false),
                        client_Id = c.Int(),
                        module_Id = c.Int(),
                        project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.H_CYKP_Log", "DateTypeID", "dbo.H_CYKP_DateTypes");
            DropIndex("dbo.H_CYKP_Log", new[] { "DateTypeID" });
            DropColumn("dbo.H_CYKP_Log", "DateTypeID");
            CreateIndex("dbo.H_CYKP_Date", "project_Id");
            CreateIndex("dbo.H_CYKP_Date", "module_Id");
            CreateIndex("dbo.H_CYKP_Date", "client_Id");
            CreateIndex("dbo.H_CYKP_Date", "DateTypeID");
            CreateIndex("dbo.H_CYKP_Date", "TypeModeID");
            AddForeignKey("dbo.H_CYKP_Date", "DateTypeID", "dbo.H_CYKP_DateTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.H_CYKP_Date", "TypeModeID", "dbo.H_CYKP_TypeMode", "Id", cascadeDelete: true);
            AddForeignKey("dbo.H_CYKP_Date", "project_Id", "dbo.H_CYKP_Name_Project", "Id");
            AddForeignKey("dbo.H_CYKP_Date", "module_Id", "dbo.H_CYKP_NameModule", "Id");
            AddForeignKey("dbo.H_CYKP_Date", "client_Id", "dbo.H_CYKP_Name_Client", "Id");
        }
    }
}
