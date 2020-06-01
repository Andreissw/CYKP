namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.H_CYKP_Users", name: "Status_Id", newName: "StatusId");
            RenameIndex(table: "dbo.H_CYKP_Users", name: "IX_Status_Id", newName: "IX_StatusId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.H_CYKP_Users", name: "IX_StatusId", newName: "IX_Status_Id");
            RenameColumn(table: "dbo.H_CYKP_Users", name: "StatusId", newName: "Status_Id");
        }
    }
}
