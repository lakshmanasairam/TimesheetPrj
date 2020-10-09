namespace TimesheetPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Times", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.Times", "Experience", c => c.Int(nullable: false));
            AlterColumn("dbo.Times", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Times", "Status", c => c.String());
            AlterColumn("dbo.Times", "Experience", c => c.Int());
            AlterColumn("dbo.Times", "Role", c => c.String());
        }
    }
}
