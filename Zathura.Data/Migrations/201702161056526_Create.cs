namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentTypes",
                c => new
                    {
                        ContentTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ContentTypeId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Content_ContentId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Contents", t => t.Content_ContentId)
                .Index(t => t.Content_ContentId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(maxLength: 250),
                        Description = c.String(maxLength: 2000),
                        ViewCount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ImageItem = c.String(maxLength: 255),
                        ContentType_ContentTypeId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.ContentTypes", t => t.ContentType_ContentTypeId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.ContentType_ContentTypeId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 16),
                        CreateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Rol_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.Rol_RoleId)
                .Index(t => t.Rol_RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Rol_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Images", "Content_ContentId", "dbo.Contents");
            DropForeignKey("dbo.Contents", "ContentType_ContentTypeId", "dbo.ContentTypes");
            DropIndex("dbo.Users", new[] { "Rol_RoleId" });
            DropIndex("dbo.Contents", new[] { "User_UserId" });
            DropIndex("dbo.Contents", new[] { "ContentType_ContentTypeId" });
            DropIndex("dbo.Images", new[] { "Content_ContentId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Contents");
            DropTable("dbo.Images");
            DropTable("dbo.ContentTypes");
        }
    }
}
