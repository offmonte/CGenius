using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstOne.Data;
using FirstOne.Models;
using FirstOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FirstOne.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly dbContext _dbContext;

        public VendaRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Venda>> GetVendas()
        {
            return await _dbContext.Vendas.ToListAsync();
        }

        public async Task<Venda> GetVenda(int idVenda)
        {
            return await _dbContext.Vendas.FirstOrDefaultAsync(v => v.IdVenda == idVenda);
        }

        public async Task<Venda> AddVenda(Venda venda)
        {
            var result = await _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Venda> UpdateVenda(Venda venda)
        {
            var existingVenda = await _dbContext.Vendas.FirstOrDefaultAsync(v => v.IdVenda == venda.IdVenda);
            if (existingVenda != null)
            {
                existingVenda.CpfAtendente = venda.CpfAtendente;
                existingVenda.CpfCliente = venda.CpfCliente;
                existingVenda.IdScript = venda.IdScript;
                existingVenda.IdPlano = venda.IdPlano;
                existingVenda.IdEspecificacao = venda.IdEspecificacao;

                await _dbContext.SaveChangesAsync();
                return existingVenda;
            }

            return null;
        }

        public async void DeleteVenda(int idVenda)
        {
            var venda = await _dbContext.Vendas.FirstOrDefaultAsync(v => v.IdVenda == idVenda);
            if (venda != null)
            {
                _dbContext.Vendas.Remove(venda);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
