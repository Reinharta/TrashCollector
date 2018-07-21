namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class springcleaning : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerUsers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.EmployeeUsers", "Address", "dbo.Addresses");
            DropIndex("dbo.CustomerUsers", new[] { "AddressId" });
            DropIndex("dbo.EmployeeUsers", new[] { "Address" });
            AddColumn("dbo.CustomerUsers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerUsers", "UserId");
            AddForeignKey("dbo.CustomerUsers", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.CustomerUsers", "Id");
            DropTable("dbo.Cities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EmployeeUsers", "Address", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerUsers", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerUsers", "Id", c => c.String());
            DropForeignKey("dbo.CustomerUsers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerUsers", new[] { "UserId" });
            DropColumn("dbo.CustomerUsers", "UserId");
            CreateIndex("dbo.EmployeeUsers", "Address");
            CreateIndex("dbo.CustomerUsers", "AddressId");
            AddForeignKey("dbo.EmployeeUsers", "Address", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerUsers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
