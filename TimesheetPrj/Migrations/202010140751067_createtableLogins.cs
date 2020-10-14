namespace TimesheetPrj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtableLogins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
        }
    }
}
