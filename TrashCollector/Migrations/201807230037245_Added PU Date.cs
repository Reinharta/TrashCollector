namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPUDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PickUps", "PickUpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PickUps", "PickUpDate");
        }
    }
}
