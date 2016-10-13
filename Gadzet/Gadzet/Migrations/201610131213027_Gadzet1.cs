namespace Gadzet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gadzet1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Handlowiecs", "HandlowiecVIP", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Handlowiecs", "HandlowiecVIP");
        }
    }
}
