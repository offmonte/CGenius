using CGenius.Models;
using Microsoft.EntityFrameworkCore;

namespace CGenius.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Especificacao> Especificacoes { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais

            // Configura as chaves estrangeiras
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Script)
                .WithMany(s => s.Clientes)
                .HasForeignKey(c => c.IdScript);

            modelBuilder.Entity<Especificacao>()
                .HasOne(e => e.Cliente)
                .WithOne(c => c.Especificacao)
                .HasForeignKey<Especificacao>(e => e.CpfCliente);

            modelBuilder.Entity<Script>()
                .HasOne(s => s.Plano)
                .WithMany(p => p.Scripts)
                .HasForeignKey(s => s.IdPlano);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Atendente)
                .WithMany(a => a.Vendas)
                .HasForeignKey(v => v.CpfAtendente);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Vendas)
                .HasForeignKey(v => v.CpfCliente);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Script)
                .WithMany(s => s.Vendas)
                .HasForeignKey(v => v.IdScript);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Plano)
                .WithMany(p => p.Vendas)
                .HasForeignKey(v => v.IdPlano);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Especificacao)
                .WithMany()
                .HasForeignKey(v => v.IdEspecificacao);
        }
    }
}