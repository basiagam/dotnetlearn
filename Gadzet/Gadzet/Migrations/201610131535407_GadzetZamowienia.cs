namespace Gadzet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GadzetZamowienia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zamowienies",
                c => new
                    {
                        IdZamowienie = c.Int(nullable: false, identity: true),
                        IdHandlowiec = c.Int(nullable: false),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DataZamowienia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdZamowienie)
                .ForeignKey("dbo.Handlowiecs", t => t.IdHandlowiec, cascadeDelete: true)
                .Index(t => t.IdHandlowiec);
            
            CreateTable(
                "dbo.ZamowieniePozycjas",
                c => new
                    {
                        IdZamowieniePozycja = c.Int(nullable: false, identity: true),
                        IdTowar = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Wartosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdZamowienie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdZamowieniePozycja)
                .ForeignKey("dbo.Towars", t => t.IdTowar, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienies", t => t.IdZamowienie, cascadeDelete: true)
                .Index(t => t.IdTowar)
                .Index(t => t.IdZamowienie);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZamowieniePozycjas", "IdZamowienie", "dbo.Zamowienies");
            DropForeignKey("dbo.ZamowieniePozycjas", "IdTowar", "dbo.Towars");
            DropForeignKey("dbo.Zamowienies", "IdHandlowiec", "dbo.Handlowiecs");
            DropIndex("dbo.ZamowieniePozycjas", new[] { "IdZamowienie" });
            DropIndex("dbo.ZamowieniePozycjas", new[] { "IdTowar" });
            DropIndex("dbo.Zamowienies", new[] { "IdHandlowiec" });
            DropTable("dbo.ZamowieniePozycjas");
            DropTable("dbo.Zamowienies");
        }
    }
}
