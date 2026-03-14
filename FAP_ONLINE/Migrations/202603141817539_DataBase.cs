namespace FAP_ONLINE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarifas", "ValorPorMinuto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tarifas", "Origem", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Tarifas", "Destino", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.Tarifas", "ValorPorMinutos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarifas", "ValorPorMinutos", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tarifas", "Destino", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Tarifas", "Origem", c => c.String(nullable: false, maxLength: 2));
            DropColumn("dbo.Tarifas", "ValorPorMinuto");
        }
    }
}
