using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstOne.Models
{
    public class Script
    {
        [Key]
        public int IdScript { get; set; }

        public string DescricaoScript { get; set; }

        [ForeignKey("Plano")]
        public int IdPlano { get; set; }
        public Plano Plano { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
