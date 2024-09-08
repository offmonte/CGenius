using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstOne.Models
{
    public class Especificacao
    {
        [Key]
        public int IdEspecificacao { get; set; }

        [StringLength(10)]
        public string TipoCartaoCredito { get; set; }

        [Required]
        public decimal GastoMensal { get; set; }

        [Required]
        public bool ViajaFrequentemente { get; set; }

        [StringLength(50)]
        public string Interesses { get; set; }

        [StringLength(30)]
        public string Profissao { get; set; }

        [Required]
        public decimal RendaMensal { get; set; }

        [Required]
        public int Dependentes { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        [StringLength(11)]
        public string CpfCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}