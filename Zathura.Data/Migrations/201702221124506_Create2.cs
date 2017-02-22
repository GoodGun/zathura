namespace Zathura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Rol_RoleId", newName: "Role_RoleId");
            RenameIndex(table: "dbo.Users", name: "IX_Rol_RoleId", newName: "IX_Role_RoleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_Role_RoleId", newName: "IX_Rol_RoleId");
            RenameColumn(table: "dbo.Users", name: "Role_RoleId", newName: "Rol_RoleId");
        }
    }
}
