namespace FAP_ONLINE.Migrations
{
    using FAP_ONLINE.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FAP_ONLINE.Data.Context>
    {
        public Configuration()
        {
            //Migrações manuais para maior controle
            AutomaticMigrationsEnabled = false;
        }

        //Popula o banco de dados com os dados iniciais necessários para funcionamento
        protected override void Seed(FAP_ONLINE.Data.Context context)
        {

            //Cadastra os planos disponíveis usando o nome como chave para evitar duplicatas
            context.Planos.AddOrUpdate(p => p.PlanoNome,
                new Plano { PlanoNome = "Fale Mais 30", MinutosGratuitos = 30 },
                new Plano { PlanoNome = "Fale Mais 60", MinutosGratuitos = 60 },
                new Plano { PlanoNome = "Fale Mais 120", MinutosGratuitos = 120 }
            );

            //Cadastra as tarifas por minuto usando a combinação de origem e destino como chave para evitar duplicatas
            context.Tarifas.AddOrUpdate(t => new { t.Origem, t.Destino },
                new Tarifa { Origem = "011", Destino = "016", ValorPorMinuto = 1.90m },
                new Tarifa { Origem = "016", Destino = "011", ValorPorMinuto = 2.90m },
                new Tarifa { Origem = "011", Destino = "017", ValorPorMinuto = 1.70m },
                new Tarifa { Origem = "017", Destino = "011", ValorPorMinuto = 2.70m },
                new Tarifa { Origem = "011", Destino = "018", ValorPorMinuto = 0.90m },
                new Tarifa { Origem = "018", Destino = "011", ValorPorMinuto = 1.90m }
            );
        }
    }
}
