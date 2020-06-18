namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_LogDocuments", "ClientId", "dbo.H_CYKP_Name_Client");
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "ClientId" });
            RenameColumn(table: "dbo.H_CYKP_LogDocuments", name: "ProjectId", newName: "OrderId");
            RenameIndex(table: "dbo.H_CYKP_LogDocuments", name: "IX_ProjectId", newName: "IX_OrderId");
            AlterColumn("dbo.H_CYKP_LogDocuments", "ClientId", c => c.Int());
            CreateIndex("dbo.H_CYKP_LogDocuments", "ClientId");
            AddForeignKey("dbo.H_CYKP_LogDocuments", "ClientId", "dbo.H_CYKP_Name_Client", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_LogDocuments", "ClientId", "dbo.H_CYKP_Name_Client");
            DropIndex("dbo.H_CYKP_LogDocuments", new[] { "ClientId" });
            AlterColumn("dbo.H_CYKP_LogDocuments", "ClientId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.H_CYKP_LogDocuments", name: "IX_OrderId", newName: "IX_ProjectId");
            RenameColumn(table: "dbo.H_CYKP_LogDocuments", name: "OrderId", newName: "ProjectId");
            CreateIndex("dbo.H_CYKP_LogDocuments", "ClientId");
            AddForeignKey("dbo.H_CYKP_LogDocuments", "ClientId", "dbo.H_CYKP_Name_Client", "Id", cascadeDelete: true);
        }
    }
}
