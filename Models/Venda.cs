using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CGenius.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }

        [ForeignKey("Atendente")]
        
        [StringLength(11)]
        public string CpfAtendente { get; set; }
        public Atendente Atendente { get; set; }

        [ForeignKey("Cliente")]
        
        [StringLength(11)]
        public string CpfCliente { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Script")]
        
        public int IdScript { get; set; }
        public Script Script { get; set; }

        [ForeignKey("Plano")]
        
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }

        [ForeignKey("Especificacao")]
        
        public int IdEspecificacao { get; set; }
        public Especificacao Especificacao { get; set; }
    }
}
