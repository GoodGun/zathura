namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemSettings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SystemSettings", "Name");
        }
    }
}
