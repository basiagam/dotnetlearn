namespace Gadzety.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TowarViewModels", "IdKategoria", "dbo.Kategorias");
            DropIndex("dbo.TowarViewModels", new[] { "IdKategoria" });
            DropTable("dbo.TowarViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TowarViewModels",
                c => new
                    {
                        IdTowar = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TowarPromocyjny = c.Boolean(nullable: false),
                        TowarPolecany = c.Boolean(nullable: false),
                        IdKategoria = c.Int(nullable: false),
                        AktualnyStan = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdTowar);
            
            CreateIndex("dbo.TowarViewModels", "IdKategoria");
            AddForeignKey("dbo.TowarViewModels", "IdKategoria", "dbo.Kategorias", "IdKategoria", cascadeDelete: true);
        }
    }
}
