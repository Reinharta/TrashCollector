namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrolecolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerUsers", "Id", c => c.String());
            AddColumn("dbo.EmployeeUsers", "Id", c => c.String());
            AlterColumn("dbo.EmployeeUsers", "PhoneNumber", c => c.String());
            DropColumn("dbo.CustomerUsers", "UserId");
            DropColumn("dbo.EmployeeUsers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeUsers", "UserId", c => c.String());
            AddColumn("dbo.CustomerUsers", "UserId", c => c.String());
            AlterColumn("dbo.EmployeeUsers", "PhoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.EmployeeUsers", "Id");
            DropColumn("dbo.CustomerUsers", "Id");
        }
    }
}
