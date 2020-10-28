namespace TimesheetPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechangesinsignin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Signins", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Signins", "password", c => c.String(nullable: false));
            AlterColumn("dbo.Signins", "ConfirmPassword", c => c.String(nullable: false));
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.Signins", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Signins", "password", c => c.String());
            AlterColumn("dbo.Signins", "Username", c => c.String());
        }
    }
}
