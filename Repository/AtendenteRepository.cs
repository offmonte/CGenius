using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CGenius.Models;
using CGenius.Repository.Interface;
using CGenius.Data;

namespace CGenius.Repository
{
    public class AtendenteRepository : IAtendenteRepository
    {
        private readonly dbContext _dbContext;

        public AtendenteRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Atendente>> GetAtendentes()
        {
            return await _dbContext.Atendentes.ToListAsync();
        }

        public async Task<Atendente> GetAtendente(string cpf)
        {
            return await _dbContext.Atendentes.FirstOrDefaultAsync(a => a.CpfAtendente == cpf);
        }

        public async Task<Atendente> AddAtendente(Atendente atendente)
        {
            var result = await _dbContext.Atendentes.AddAsync(atendente);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Atendente> UpdateAtendente(Atendente atendente)
        {
            var result = await _dbContext.Atendentes.FirstOrDefaultAsync(a => a.CpfAtendente == atendente.CpfAtendente);
            if (result != null)
            {
                result.NomeAtendente = atendente.NomeAtendente;
                result.Setor = atendente.Setor;
                result.Senha = atendente.Senha;
                result.PerfilAtendente = atendente.PerfilAtendente;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteAtendente(string cpf)
        {
            var result = await _dbContext.Atendentes.FirstOrDefaultAsync(a => a.CpfAtendente == cpf);
            if (result != null)
            {
                _dbContext.Atendentes.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
