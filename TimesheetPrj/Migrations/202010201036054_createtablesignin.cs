namespace TimesheetPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablesignin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Signins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Signins");
        }
    }
}
