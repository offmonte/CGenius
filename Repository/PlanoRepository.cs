using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGenius.Data;
using CGenius.Models;
using CGenius.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CGenius.Repository
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly dbContext _dbContext;

        public PlanoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plano>> GetPlanos()
        {
            return await _dbContext.Planos.ToListAsync();
        }

        public async Task<Plano> GetPlano(int idPlano)
        {
            return await _dbContext.Planos.FirstOrDefaultAsync(p => p.IdPlano == idPlano);
        }

        public async Task<Plano> AddPlano(Plano plano)
        {
            var result = await _dbContext.Planos.AddAsync(plano);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Plano> UpdatePlano(Plano plano)
        {
            var existingPlano = await _dbContext.Planos.FirstOrDefaultAsync(p => p.IdPlano == plano.IdPlano);
            if (existingPlano != null)
            {
                existingPlano.NomePlano = plano.NomePlano;
                existingPlano.DescricaoPlano = plano.DescricaoPlano;
                existingPlano.ValorPlano = plano.ValorPlano;

                await _dbContext.SaveChangesAsync();
                return existingPlano;
            }

            return null;
        }

        public async Task DeletePlano(int idPlano)
        {
            var plano = await _dbContext.Planos.FirstOrDefaultAsync(p => p.IdPlano == idPlano);
            if (plano != null)
            {
                _dbContext.Planos.Remove(plano);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
