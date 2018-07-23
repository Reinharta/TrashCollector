namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exceptioninstartup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PickUps", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PickUps", "StreetAddress", c => c.String(nullable: false));
        }
    }
}
