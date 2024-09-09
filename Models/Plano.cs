using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CGenius.Models
{
    public class Plano
    {
        [Key]
        public int IdPlano { get; set; }

        [Required]
        [StringLength(30)]
        public string NomePlano { get; set; }

        [StringLength(100)]
        public string DescricaoPlano { get; set; }

        [Required]
        public decimal ValorPlano { get; set; }

        public ICollection<Script> Scripts { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
