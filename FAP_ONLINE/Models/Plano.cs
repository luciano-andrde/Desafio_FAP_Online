using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FAP_ONLINE.Models
{
    //Usado pelo Entity Framework no mapeamento da tabela no banco de dados
    [Table("Planos")]
    public class Plano
    {
        [Key] //Entity Framework usa para identificar a primary key e gerar auto-increment no banco de dados
        public int PlanoID { get; set; }

        [Required(ErrorMessage = "O nome do plano é obrigatório."), StringLength(50)] //Evita nomes nulos ou muito grandes no banco de dados 
        public string PlanoNome { get; set; }

        [Required(ErrorMessage = "O plano deve ter uma quantidade de minutos gratuitos.")] //Evita valores nulos para a quantidade de minutos gratuitos do plano
        public int MinutosGratuitos { get; set; }
    }
}