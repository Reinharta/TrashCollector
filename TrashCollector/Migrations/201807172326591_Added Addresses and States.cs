namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressesandStates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeUsers", "FirstName", c => c.String());
            AddColumn("dbo.EmployeeUsers", "LastName", c => c.String());
            AddColumn("dbo.EmployeeUsers", "PhoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeUsers", "PhoneNumber");
            DropColumn("dbo.EmployeeUsers", "LastName");
            DropColumn("dbo.EmployeeUsers", "FirstName");
        }
    }
}
