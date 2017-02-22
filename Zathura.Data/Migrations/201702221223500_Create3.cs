namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        ParentCategoryId = c.Int(nullable: false),
                        Url = c.String(maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Contents", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Contents", "Category_CategoryId");
            AddForeignKey("dbo.Contents", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "Category_CategoryId" });
            DropColumn("dbo.Contents", "Category_CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
