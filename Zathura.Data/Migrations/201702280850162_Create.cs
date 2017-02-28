namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentCategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Url = c.String(maxLength: 150),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(maxLength: 250),
                        Description = c.String(maxLength: 2000),
                        ViewCount = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ContentType = c.Int(nullable: false),
                        MediaItem = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Category_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Content_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contents", t => t.Content_ID)
                .Index(t => t.Content_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 16),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Contents", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Media", "Content_ID", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Media", new[] { "Content_ID" });
            DropIndex("dbo.Contents", new[] { "User_ID" });
            DropIndex("dbo.Contents", new[] { "Category_ID" });
            DropIndex("dbo.Categories", new[] { "User_ID" });
            DropTable("dbo.SystemSettings");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Media");
            DropTable("dbo.Contents");
            DropTable("dbo.Categories");
        }
    }
}
