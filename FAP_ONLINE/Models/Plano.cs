using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FAP_ONLINE.Models
{
    [Table("Planos")]
    public class Plano
    {
        [Key]
        public int PlanoID { get; set; }

        [Required(ErrorMessage = "O nome do plano é obrigatório."), StringLength(50)]
        public string PlanoName { get; set; }

        [Required(ErrorMessage = "O plano deve ter uma quantidade de minutos gratuitos.")]
        public int MinutosGratuitos { get; set; }
    }
}