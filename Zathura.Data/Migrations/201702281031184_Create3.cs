namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.MediaItems", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Contents", "ContentType");
            DropColumn("dbo.MediaItems", "ContentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MediaItems", "ContentType", c => c.Int(nullable: false));
            AddColumn("dbo.Contents", "ContentType", c => c.Int(nullable: false));
            DropColumn("dbo.MediaItems", "Type");
            DropColumn("dbo.Contents", "Type");
        }
    }
}
