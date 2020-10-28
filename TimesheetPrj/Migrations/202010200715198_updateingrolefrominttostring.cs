namespace TimesheetPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateingrolefrominttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Logins", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Times", "Experience", c => c.String(nullable: false));
            AlterColumn("dbo.Times", "Taskdes", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Times", "Taskdes", c => c.String());
            AlterColumn("dbo.Times", "Experience", c => c.Int(nullable: false));
            AlterColumn("dbo.Logins", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Logins", "Password", c => c.String());
            AlterColumn("dbo.Logins", "Username", c => c.String());
        }
    }
}
