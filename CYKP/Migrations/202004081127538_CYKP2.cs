namespace CYKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CYKP2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.H_CYKP_GridMenuName",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.H_CYKP_GridMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IdMenuName_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.H_CYKP_GridMenuName", t => t.IdMenuName_Id, cascadeDelete: true)
                .Index(t => t.IdMenuName_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.H_CYKP_GridMenu", "IdMenuName_Id", "dbo.H_CYKP_GridMenuName");
            DropIndex("dbo.H_CYKP_GridMenu", new[] { "IdMenuName_Id" });
            DropTable("dbo.H_CYKP_GridMenu");
            DropTable("dbo.H_CYKP_GridMenuName");
        }
    }
}
