using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAP_ONLINE.Models
{
    [Table("Tarifas")]
    public class Tarifa
    {
        [Key]
        public int TarifaID { get; set; }

        [Required, StringLength(2)]
        public string Origem { get; set; }

        [Required,StringLength(2)]
        public string Destino { get; set; }

        [Required, Column(TypeName = "decimal")]
        public decimal ValorPorMinutos { get; set; }
    }
}