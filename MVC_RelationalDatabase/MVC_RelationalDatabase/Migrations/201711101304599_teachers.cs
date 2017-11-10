namespace MVC_RelationalDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Name");
        }
    }
}
