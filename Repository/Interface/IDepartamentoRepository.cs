using FirstOne.Models;

namespace FirstOne.Repository.Interface
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetDepartamentos();
        Task<Departamento> GetDepartamento(int id);
        Task<Departamento> AddDepartamento(Departamento departamento);
        Task<Departamento> UpdateDepartamento(Departamento departamento);
        Task DeleteDepartamento(int id);
    }
}