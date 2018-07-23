namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedcustCreateVMupdatepickupsmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PickUps", "CustomerId_CustomerId", "dbo.CustomerUsers");
            DropIndex("dbo.PickUps", new[] { "CustomerId_CustomerId" });
            RenameColumn(table: "dbo.PickUps", name: "CustomerId_CustomerId", newName: "CustomerId");
            AddColumn("dbo.PickUps", "StreetAddress", c => c.String(nullable: false));
            AddColumn("dbo.PickUps", "Zipcode", c => c.Int(nullable: false));
            AddColumn("dbo.PickUps", "Completed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PickUps", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.PickUps", "CustomerId");
            AddForeignKey("dbo.PickUps", "CustomerId", "dbo.CustomerUsers", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.PickUps", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PickUps", "Address", c => c.Int(nullable: false));
            DropForeignKey("dbo.PickUps", "CustomerId", "dbo.CustomerUsers");
            DropIndex("dbo.PickUps", new[] { "CustomerId" });
            AlterColumn("dbo.PickUps", "CustomerId", c => c.Int());
            DropColumn("dbo.PickUps", "Completed");
            DropColumn("dbo.PickUps", "Zipcode");
            DropColumn("dbo.PickUps", "StreetAddress");
            RenameColumn(table: "dbo.PickUps", name: "CustomerId", newName: "CustomerId_CustomerId");
            CreateIndex("dbo.PickUps", "CustomerId_CustomerId");
            AddForeignKey("dbo.PickUps", "CustomerId_CustomerId", "dbo.CustomerUsers", "CustomerId");
        }
    }
}
