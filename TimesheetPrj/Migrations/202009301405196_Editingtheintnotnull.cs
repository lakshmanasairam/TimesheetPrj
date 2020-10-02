namespace TimesheetPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editingtheintnotnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Times", "Experience", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Times", "Experience", c => c.Int(nullable: false));
        }
    }
}
