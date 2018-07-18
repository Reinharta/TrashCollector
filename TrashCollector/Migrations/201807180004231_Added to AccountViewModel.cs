namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedtoAccountViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerUsers", "Role_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.EmployeeUsers", "Role_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerUsers", "Role_Id");
            CreateIndex("dbo.EmployeeUsers", "Role_Id");
            AddForeignKey("dbo.CustomerUsers", "Role_Id", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.EmployeeUsers", "Role_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeUsers", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.CustomerUsers", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.EmployeeUsers", new[] { "Role_Id" });
            DropIndex("dbo.CustomerUsers", new[] { "Role_Id" });
            DropColumn("dbo.EmployeeUsers", "Role_Id");
            DropColumn("dbo.CustomerUsers", "Role_Id");
        }
    }
}
