namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_Log", "TypeDateId", "dbo.H_CYKP_DateTypes");
            DropIndex("dbo.H_CYKP_Log", new[] { "TypeDateId" });
            AddColumn("dbo.H_CYKP_Name_Client", "Date", c => c.DateTime());
            AddColumn("dbo.H_CYKP_Name_Client", "DateTypeID", c => c.Int());
            CreateIndex("dbo.H_CYKP_Name_Client", "DateTypeID");
            AddForeignKey("dbo.H_CYKP_Name_Client", "DateTypeID", "dbo.H_CYKP_DateTypes", "Id");
            DropColumn("dbo.H_CYKP_Log", "TypeDateId");
        }
        
        public override void Down()
        {
            
            AddColumn("dbo.H_CYKP_Log", "TypeDateId", c => c.Int(nullable: false));
            DropForeignKey("dbo.H_CYKP_Name_Client", "DateTypeID", "dbo.H_CYKP_DateTypes");
            DropIndex("dbo.H_CYKP_Name_Client", new[] { "DateTypeID" });
            DropColumn("dbo.H_CYKP_Name_Client", "DateTypeID");
            DropColumn("dbo.H_CYKP_Name_Client", "Date");
            CreateIndex("dbo.H_CYKP_Log", "TypeDateId");
            AddForeignKey("dbo.H_CYKP_Log", "TypeDateId", "dbo.H_CYKP_DateTypes", "Id", cascadeDelete: true);
        }
    }
}
