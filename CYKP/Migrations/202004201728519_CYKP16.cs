namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.H_CYKP_LogInfo", "srtName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.H_CYKP_LogInfo", "srtName", c => c.String(nullable: false));
        }
    }
}
