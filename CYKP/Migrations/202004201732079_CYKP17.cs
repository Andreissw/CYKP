namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.H_CYKP_LogInfo", "StatusID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.H_CYKP_LogInfo", "StatusID");
        }
    }
}
