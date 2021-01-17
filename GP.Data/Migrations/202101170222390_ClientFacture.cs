namespace GP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientFacture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        DateAchat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProductFk = c.Int(nullable: false),
                        ClientFk = c.Int(nullable: false),
                        Prix = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DateAchat, t.ProductFk, t.ClientFk })
                .ForeignKey("dbo.Clients", t => t.ClientFk, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductFk, cascadeDelete: true)
                .Index(t => t.ProductFk)
                .Index(t => t.ClientFk);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CIN = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.CIN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factures", "ProductFk", "dbo.Products");
            DropForeignKey("dbo.Factures", "ClientFk", "dbo.Clients");
            DropIndex("dbo.Factures", new[] { "ClientFk" });
            DropIndex("dbo.Factures", new[] { "ProductFk" });
            DropTable("dbo.Clients");
            DropTable("dbo.Factures");
        }
    }
}
