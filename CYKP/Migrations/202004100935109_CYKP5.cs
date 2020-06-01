namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.H_CYKP_StatusProduct", "ModeId", c => c.Int(nullable: false));
            AddColumn("dbo.H_CYKP_StatusProduct", "Modelid_Id", c => c.Int());
            CreateIndex("dbo.H_CYKP_StatusProduct", "Modelid_Id");
            AddForeignKey("dbo.H_CYKP_StatusProduct", "Modelid_Id", "dbo.H_CYKP_TypeMode", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_StatusProduct", "Modelid_Id", "dbo.H_CYKP_TypeMode");
            DropIndex("dbo.H_CYKP_StatusProduct", new[] { "Modelid_Id" });
            DropColumn("dbo.H_CYKP_StatusProduct", "Modelid_Id");
            DropColumn("dbo.H_CYKP_StatusProduct", "ModeId");
        }
    }
}
