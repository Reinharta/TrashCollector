namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedempaddedVM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeUsers", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeUsers", new[] { "AppUser_Id" });
            DropColumn("dbo.EmployeeUsers", "AppUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeUsers", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.EmployeeUsers", "AppUser_Id");
            AddForeignKey("dbo.EmployeeUsers", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
