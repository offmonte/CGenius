using System.ComponentModel.DataAnnotations;

namespace CGenius.Models
{
    public class Atendente
    {
        [Key]
        [Required]
        [StringLength(11)]
        public string CpfAtendente { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeAtendente { get; set; }

        [StringLength(20)]
        public string Setor { get; set; }

        [StringLength(10)]
        public string Senha { get; set; }

        [StringLength(30)]
        public string PerfilAtendente { get; set; }

        public ICollection<Venda> Vendas { get; set; }
    }
}