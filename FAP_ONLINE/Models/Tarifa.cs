using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAP_ONLINE.Models
{
    //Usado pelo Entity Framework no mapeamento da tabela no banco de dados
    [Table("Tarifas")]
    public class Tarifa
    {
        [Key] //Entity Framework usa para identificar a primary key e gerar auto-increment no banco de dados
        public int TarifaID { get; set; }

        [Required, StringLength(3)] //Evita valores nulos ou valores diferentes do padrão de DDD (3 algarismos)
        public string Origem { get; set; }

        [Required, StringLength(3)] //Evita valores nulos ou valores diferentes do padrão de DDD (3 algarismos)
        public string Destino { get; set; }

        [Required, Column(TypeName = "decimal")] //Evita valores nulos e limita os numeros para no máximo 10 algarismos com 2 casas após a vírgula
        public decimal ValorPorMinuto { get; set; }
    }
}