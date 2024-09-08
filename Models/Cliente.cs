using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstOne.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        [StringLength(11)]
        public string CpfCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeCliente { get; set; }

        [Required]
        public DateTime DtNascimento { get; set; }

        [StringLength(10)]
        public string Genero { get; set; }

        [StringLength(8)]
        public string Cep { get; set; }

        [StringLength(11)]
        public string Telefone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string PerfilCliente { get; set; }

        [ForeignKey("Script")]
        public int IdScript { get; set; }
        public Script Script { get; set; }

        public Especificacao Especificacao { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
