namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedandfixFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerUsers", "Role", "dbo.AspNetRoles");
            DropForeignKey("dbo.EmployeeUsers", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.CustomerUsers", new[] { "UserId" });
            DropIndex("dbo.CustomerUsers", new[] { "Role" });
            DropIndex("dbo.EmployeeUsers", new[] { "Role_Id" });
            RenameColumn(table: "dbo.CustomerUsers", name: "Address", newName: "AddressId");
            RenameIndex(table: "dbo.CustomerUsers", name: "IX_Address", newName: "IX_AddressId");
            AlterColumn("dbo.CustomerUsers", "UserId", c => c.String());
            CreateIndex("dbo.EmployeeUsers", "Address");
            AddForeignKey("dbo.EmployeeUsers", "Address", "dbo.Addresses", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeUsers", "Role_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.CustomerUsers", "Role", c => c.String(maxLength: 128));
            DropForeignKey("dbo.EmployeeUsers", "Address", "dbo.Addresses");
            DropIndex("dbo.EmployeeUsers", new[] { "Address" });
            AlterColumn("dbo.CustomerUsers", "UserId", c => c.String(maxLength: 128));
            RenameIndex(table: "dbo.CustomerUsers", name: "IX_AddressId", newName: "IX_Address");
            RenameColumn(table: "dbo.CustomerUsers", name: "AddressId", newName: "Address");
            CreateIndex("dbo.EmployeeUsers", "Role_Id");
            CreateIndex("dbo.CustomerUsers", "Role");
            CreateIndex("dbo.CustomerUsers", "UserId");
            AddForeignKey("dbo.EmployeeUsers", "Role_Id", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.CustomerUsers", "Role", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.CustomerUsers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
