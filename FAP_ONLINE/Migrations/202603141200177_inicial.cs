namespace FAP_ONLINE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planos",
                c => new
                    {
                        PlanoID = c.Int(nullable: false, identity: true),
                        PlanoNome = c.String(nullable: false, maxLength: 50),
                        MinutosGratuitos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanoID);
            
            CreateTable(
                "dbo.Tarifas",
                c => new
                    {
                        TarifaID = c.Int(nullable: false, identity: true),
                        Origem = c.String(nullable: false, maxLength: 2),
                        Destino = c.String(nullable: false, maxLength: 2),
                        ValorPorMinutos = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TarifaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarifas");
            DropTable("dbo.Planos");
        }
    }
}
