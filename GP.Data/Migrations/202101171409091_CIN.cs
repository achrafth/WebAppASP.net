namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CIN : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Factures", "ProductFk", "dbo.Products");
            DropForeignKey("dbo.Factures", "ClientFk", "dbo.Clients");
            AddForeignKey("dbo.Factures", "ProductFk", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Factures", "ClientFk", "dbo.Clients", "CIN");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factures", "ClientFk", "dbo.Clients");
            DropForeignKey("dbo.Factures", "ProductFk", "dbo.Products");
            AddForeignKey("dbo.Factures", "ClientFk", "dbo.Clients", "CIN", cascadeDelete: true);
            AddForeignKey("dbo.Factures", "ProductFk", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
