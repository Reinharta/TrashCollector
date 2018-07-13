namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDBSetforemployeeandcustomerusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerUsers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Address = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.EmployeeUsers",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Address = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeUsers");
            DropTable("dbo.CustomerUsers");
        }
    }
}
