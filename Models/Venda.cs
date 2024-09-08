using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstOne.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }

        [ForeignKey("Atendente")]
        [Required]
        [StringLength(11)]
        public string CpfAtendente { get; set; }
        public Atendente Atendente { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        [StringLength(11)]
        public string CpfCliente { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Script")]
        [Required]
        public int IdScript { get; set; }
        public Script Script { get; set; }

        [ForeignKey("Plano")]
        [Required]
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }

        [ForeignKey("Especificacao")]
        [Required]
        public int IdEspecificacao { get; set; }
        public Especificacao Especificacao { get; set; }
    }
}
