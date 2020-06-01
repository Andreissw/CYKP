namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.H_CYKP_LogInfo", "FactDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.H_CYKP_Log", "DateFact");
        }
        
        public override void Down()
        {
            AddColumn("dbo.H_CYKP_Log", "DateFact", c => c.DateTime(nullable: false));
            DropColumn("dbo.H_CYKP_LogInfo", "FactDate");
        }
    }
}
