namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "User_ID", c => c.Int());
            CreateIndex("dbo.Categories", "User_ID");
            AddForeignKey("dbo.Categories", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_ID", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "User_ID" });
            DropColumn("dbo.Categories", "User_ID");
        }
    }
}
