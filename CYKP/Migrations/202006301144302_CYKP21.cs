namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.H_CYKP_GridMenu", "StatusUserId", c => c.Int(nullable: true));
            CreateIndex("dbo.H_CYKP_GridMenu", "StatusUserId");
            AddForeignKey("dbo.H_CYKP_GridMenu", "StatusUserId", "dbo.H_CYKP_StatusUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_GridMenu", "StatusUserId", "dbo.H_CYKP_StatusUser");
            DropIndex("dbo.H_CYKP_GridMenu", new[] { "StatusUserId" });
            DropColumn("dbo.H_CYKP_GridMenu", "StatusUserId");
        }
    }
}
