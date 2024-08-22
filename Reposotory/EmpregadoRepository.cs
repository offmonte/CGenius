using FirstOne.Data;
using FirstOne.Models;
using FirstOne.Reposotory.Inteface;

namespace FirstOne.Reposotory
{
    public class EmpregadoRepository : IEmpregadoRepository
    {
        private readonly dbContext dbContext;

        public EmpregadoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Empregado> AddEmpregado(Empregado empregado)
        {
            var result = await dbContext.Empregados.AddAsync(empregado);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteEmpregado(int empId)
        {
            throw new NotImplementedException();
        }

        public Task<Empregado> GetEmpregado(int empId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Empregado>> GetEmpregados()
        {
            throw new NotImplementedException();
        }

        public Task<Empregado> UpdateEmpregado(Empregado empregado)
        {
            throw new NotImplementedException();
        }
    }
}
