namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class precontrolleradd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickUps",
                c => new
                    {
                        PickUpId = c.Int(nullable: false, identity: true),
                        Address = c.Int(nullable: false),
                        PickUpDay = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Recurring = c.Boolean(nullable: false),
                        CustomerId_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.PickUpId)
                .ForeignKey("dbo.CustomerUsers", t => t.CustomerId_CustomerId)
                .Index(t => t.CustomerId_CustomerId);
            
            AddColumn("dbo.CustomerUsers", "FirstName", c => c.String());
            AddColumn("dbo.CustomerUsers", "LastName", c => c.String());
            AddColumn("dbo.CustomerUsers", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerUsers", "UserId", c => c.String());
            AlterColumn("dbo.EmployeeUsers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickUps", "CustomerId_CustomerId", "dbo.CustomerUsers");
            DropIndex("dbo.PickUps", new[] { "CustomerId_CustomerId" });
            AlterColumn("dbo.EmployeeUsers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerUsers", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerUsers", "PhoneNumber");
            DropColumn("dbo.CustomerUsers", "LastName");
            DropColumn("dbo.CustomerUsers", "FirstName");
            DropTable("dbo.PickUps");
        }
    }
}
