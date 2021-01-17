namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NOW : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Biologicals", "ProductId", "dbo.Products");
            DropIndex("dbo.Biologicals", new[] { "ProductId" });
            AddColumn("dbo.Products", "Herbs", c => c.String());
            AddColumn("dbo.Products", "LabName", c => c.String());
            AddColumn("dbo.Products", "Address_StreetAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "Address_City", c => c.String());
            AddColumn("dbo.Products", "isBiological", c => c.Int());
            DropTable("dbo.Biologicals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Biologicals",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        LabName = c.String(),
                        Address_StreetAddress = c.String(maxLength: 50),
                        Address_City = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Herbs = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            DropColumn("dbo.Products", "isBiological");
            DropColumn("dbo.Products", "Address_City");
            DropColumn("dbo.Products", "Address_StreetAddress");
            DropColumn("dbo.Products", "LabName");
            DropColumn("dbo.Products", "Herbs");
            CreateIndex("dbo.Biologicals", "ProductId");
            AddForeignKey("dbo.Biologicals", "ProductId", "dbo.Products", "ProductId");
        }
    }
}
