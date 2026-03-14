namespace FAP_ONLINE.Migrations
{
    using FAP_ONLINE.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FAP_ONLINE.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FAP_ONLINE.Data.Context context)
        {
            context.Planos.AddOrUpdate(p => p.PlanoNome,
                new Plano { PlanoNome = "Fale Mais 30", MinutosGratuitos = 30},
                new Plano { PlanoNome = "Fale Mais 60", MinutosGratuitos = 60},
                new Plano { PlanoNome = "Fale Mais 120", MinutosGratuitos = 120}
            );

            context.Tarifa.AddOrUpdate(t => new {t.Origem, t.Destino},
                new Tarifa { Origem = "11", Destino = "16", ValorPorMinutos = 1.90m},
                new Tarifa { Origem = "16", Destino = "11", ValorPorMinutos = 2.90m},
                new Tarifa { Origem = "11", Destino = "17", ValorPorMinutos = 1.70m},
                new Tarifa { Origem = "17", Destino = "11", ValorPorMinutos = 2.70m},
                new Tarifa { Origem = "11", Destino = "18", ValorPorMinutos = 0.90m},
                new Tarifa { Origem = "18", Destino = "11", ValorPorMinutos = 1.90m}
            );
        }
    }
}
