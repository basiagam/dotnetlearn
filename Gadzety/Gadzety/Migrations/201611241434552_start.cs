namespace Gadzety.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        IdKategoria = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdKategoria);
            
            CreateTable(
                "dbo.Towars",
                c => new
                    {
                        IdTowar = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Opis = c.String(),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TowarPromocyjny = c.Boolean(nullable: false),
                        TowarPolecany = c.Boolean(nullable: false),
                        IdKategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTowar)
                .ForeignKey("dbo.Kategorias", t => t.IdKategoria, cascadeDelete: true)
                .Index(t => t.IdKategoria);
            
            CreateTable(
                "dbo.TowarStans",
                c => new
                    {
                        IdTowarStan = c.Int(nullable: false, identity: true),
                        IdTowar = c.Int(nullable: false),
                        Stan = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdTowarStan)
                .ForeignKey("dbo.Towars", t => t.IdTowar, cascadeDelete: true)
                .Index(t => t.IdTowar);
            
            CreateTable(
                "dbo.TowarZdjecies",
                c => new
                    {
                        IdTowarZdjecie = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IdTowar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTowarZdjecie)
                .ForeignKey("dbo.Towars", t => t.IdTowar, cascadeDelete: true)
                .Index(t => t.IdTowar);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TowarZdjecies", "IdTowar", "dbo.Towars");
            DropForeignKey("dbo.TowarStans", "IdTowar", "dbo.Towars");
            DropForeignKey("dbo.Towars", "IdKategoria", "dbo.Kategorias");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TowarZdjecies", new[] { "IdTowar" });
            DropIndex("dbo.TowarStans", new[] { "IdTowar" });
            DropIndex("dbo.Towars", new[] { "IdKategoria" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TowarZdjecies");
            DropTable("dbo.TowarStans");
            DropTable("dbo.Towars");
            DropTable("dbo.Kategorias");
        }
    }
}
