namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_CategoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Providers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Providers", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Providers", "Password", c => c.String());
            AlterColumn("dbo.Providers", "Email", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_CategoryId");
        }
    }
}
