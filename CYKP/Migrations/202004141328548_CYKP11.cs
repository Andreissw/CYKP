namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.H_CYKP_Name_Client", "DateTypeID", "dbo.H_CYKP_DateTypes");
            DropIndex("dbo.H_CYKP_Name_Client", new[] { "DateTypeID" });
            RenameColumn(table: "dbo.H_CYKP_DateTypes", name: "ModelId", newName: "ModeId");
            RenameIndex(table: "dbo.H_CYKP_DateTypes", name: "IX_ModelId", newName: "IX_ModeId");
            CreateTable(
                "dbo.H_CYKP_Date",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TypeModeID = c.Int(nullable: false),
                        DateTypeID = c.Int(nullable: false),
                        NameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_DateTypes", t => t.DateTypeID, cascadeDelete: true)
                .ForeignKey("dbo.H_CYKP_TypeMode", t => t.TypeModeID, cascadeDelete: true)
                .Index(t => t.TypeModeID)
                .Index(t => t.DateTypeID);
            
            DropColumn("dbo.H_CYKP_Name_Client", "Date");
            DropColumn("dbo.H_CYKP_Name_Client", "DateTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.H_CYKP_Name_Client", "DateTypeID", c => c.Int());
            AddColumn("dbo.H_CYKP_Name_Client", "Date", c => c.DateTime());
            DropForeignKey("dbo.H_CYKP_Date", "TypeModeID", "dbo.H_CYKP_TypeMode");
            DropForeignKey("dbo.H_CYKP_Date", "DateTypeID", "dbo.H_CYKP_DateTypes");
            DropIndex("dbo.H_CYKP_Date", new[] { "DateTypeID" });
            DropIndex("dbo.H_CYKP_Date", new[] { "TypeModeID" });
            DropTable("dbo.H_CYKP_Date");
            RenameIndex(table: "dbo.H_CYKP_DateTypes", name: "IX_ModeId", newName: "IX_ModelId");
            RenameColumn(table: "dbo.H_CYKP_DateTypes", name: "ModeId", newName: "ModelId");
            CreateIndex("dbo.H_CYKP_Name_Client", "DateTypeID");
            AddForeignKey("dbo.H_CYKP_Name_Client", "DateTypeID", "dbo.H_CYKP_DateTypes", "Id");
        }
    }
}
