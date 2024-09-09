
using CGenius.Data;
using CGenius.Models;
using CGenius.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CGenius.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly dbContext _dbContext;

        public DepartamentoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            return await _dbContext.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamento(int id)
        {
            return await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == id);
        }

        public async Task<Departamento> AddDepartamento(Departamento departamento)
        {
            var result = await _dbContext.Departamentos.AddAsync(departamento);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Departamento> UpdateDepartamento(Departamento departamento)
        {
            var existingDept = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == departamento.DepartamentoId);
            if (existingDept != null)
            {
                existingDept.NomeDepartamento = departamento.NomeDepartamento;
                await _dbContext.SaveChangesAsync();
                return existingDept;
            }

            return null;
        }

        public async Task DeleteDepartamento(int id)
        {
            var departamento = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.DepartamentoId == id);
            if (departamento != null)
            {
                _dbContext.Departamentos.Remove(departamento);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}