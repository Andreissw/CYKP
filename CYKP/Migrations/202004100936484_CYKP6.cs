namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_StatusProduct", "Modelid_Id", "dbo.H_CYKP_TypeMode");
            DropIndex("dbo.H_CYKP_StatusProduct", new[] { "Modelid_Id" });
            DropColumn("dbo.H_CYKP_StatusProduct", "ModeId");
            RenameColumn(table: "dbo.H_CYKP_StatusProduct", name: "Modelid_Id", newName: "ModeId");
            AlterColumn("dbo.H_CYKP_StatusProduct", "ModeId", c => c.Int(nullable: true));
            CreateIndex("dbo.H_CYKP_StatusProduct", "ModeId");
            AddForeignKey("dbo.H_CYKP_StatusProduct", "ModeId", "dbo.H_CYKP_TypeMode", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_StatusProduct", "ModeId", "dbo.H_CYKP_TypeMode");
            DropIndex("dbo.H_CYKP_StatusProduct", new[] { "ModeId" });
            AlterColumn("dbo.H_CYKP_StatusProduct", "ModeId", c => c.Int());
            RenameColumn(table: "dbo.H_CYKP_StatusProduct", name: "ModeId", newName: "Modelid_Id");
            AddColumn("dbo.H_CYKP_StatusProduct", "ModeId", c => c.Int(nullable: true));
            CreateIndex("dbo.H_CYKP_StatusProduct", "Modelid_Id");
            AddForeignKey("dbo.H_CYKP_StatusProduct", "Modelid_Id", "dbo.H_CYKP_TypeMode", "Id");
        }
    }
}
