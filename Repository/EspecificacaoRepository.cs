using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstOne.Data;
using FirstOne.Models;
using FirstOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FirstOne.Repository
{
    public class EspecificacaoRepository : IEspecificacaoRepository
    {
        private readonly dbContext _dbContext;

        public EspecificacaoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Especificacao>> GetEspecificacoes()
        {
            return await _dbContext.Especificacoes.ToListAsync();
        }

        public async Task<Especificacao> GetEspecificacao(int idEspecificacao)
        {
            return await _dbContext.Especificacoes.FirstOrDefaultAsync(e => e.IdEspecificacao == idEspecificacao);
        }

        public async Task<Especificacao> AddEspecificacao(Especificacao especificacao)
        {
            var result = await _dbContext.Especificacoes.AddAsync(especificacao);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Especificacao> UpdateEspecificacao(Especificacao especificacao)
        {
            var existingEspecificacao = await _dbContext.Especificacoes.FirstOrDefaultAsync(e => e.IdEspecificacao == especificacao.IdEspecificacao);
            if (existingEspecificacao != null)
            {
                existingEspecificacao.TipoCartaoCredito = especificacao.TipoCartaoCredito;
                existingEspecificacao.GastoMensal = especificacao.GastoMensal;
                existingEspecificacao.ViajaFrequentemente = especificacao.ViajaFrequentemente;
                existingEspecificacao.Interesses = especificacao.Interesses;
                existingEspecificacao.Profissao = especificacao.Profissao;
                existingEspecificacao.RendaMensal = especificacao.RendaMensal;
                existingEspecificacao.Dependentes = especificacao.Dependentes;
                existingEspecificacao.CpfCliente = especificacao.CpfCliente;

                await _dbContext.SaveChangesAsync();
                return existingEspecificacao;
            }

            return null;
        }

        public async void DeleteEspecificacao(int idEspecificacao)
        {
            var especificacao = await _dbContext.Especificacoes.FirstOrDefaultAsync(e => e.IdEspecificacao == idEspecificacao);
            if (especificacao != null)
            {
                _dbContext.Especificacoes.Remove(especificacao);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
