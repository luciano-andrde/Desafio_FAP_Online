using FAP_ONLINE.Models;
using System.Data.Entity;

namespace FAP_ONLINE.Data
{
    //Contexto do entity framework, responsável pela conexão com o banco de dados e mapeamento das tabelas
    public class Context : DbContext
    {
        //Conecta ao banco de dados usando a connection string "SkynetzConnection" definida no web.config
        public Context() : base("SkynetzConnection")
        {

        }

        //Representa a tabela de planos no banco de dados
        public DbSet<Plano> Planos { get; set; }

        //Representa a tabela tarifas no banco de dados
        public DbSet<Tarifa> Tarifas { get; set; }
    }
}