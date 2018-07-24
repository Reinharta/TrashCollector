namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPUdatetobilling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Billings", "PickUpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Billings", "PickUpDate");
        }
    }
}
