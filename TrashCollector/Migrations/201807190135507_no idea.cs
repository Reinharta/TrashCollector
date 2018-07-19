namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noidea : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CustomerUsers", name: "Role_Id", newName: "Role");
            RenameIndex(table: "dbo.CustomerUsers", name: "IX_Role_Id", newName: "IX_Role");
            AlterColumn("dbo.CustomerUsers", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CustomerUsers", "PhoneNumber", c => c.String());
            CreateIndex("dbo.CustomerUsers", "UserId");
            CreateIndex("dbo.CustomerUsers", "Address");
            AddForeignKey("dbo.CustomerUsers", "Address", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerUsers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerUsers", "Address", "dbo.Addresses");
            DropIndex("dbo.CustomerUsers", new[] { "Address" });
            DropIndex("dbo.CustomerUsers", new[] { "UserId" });
            AlterColumn("dbo.CustomerUsers", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerUsers", "UserId", c => c.String());
            RenameIndex(table: "dbo.CustomerUsers", name: "IX_Role", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.CustomerUsers", name: "Role", newName: "Role_Id");
        }
    }
}
