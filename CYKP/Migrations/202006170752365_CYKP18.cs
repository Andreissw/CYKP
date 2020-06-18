namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.H_CYKP_GridMenu", "row", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.H_CYKP_GridMenu", "row");
        }
    }
}
