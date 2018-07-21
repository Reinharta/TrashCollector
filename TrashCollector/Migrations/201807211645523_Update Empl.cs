namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmpl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeUsers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EmployeeUsers", "UserId");
            AddForeignKey("dbo.EmployeeUsers", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.EmployeeUsers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeUsers", "Id", c => c.String());
            DropForeignKey("dbo.EmployeeUsers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeUsers", new[] { "UserId" });
            DropColumn("dbo.EmployeeUsers", "UserId");
        }
    }
}
