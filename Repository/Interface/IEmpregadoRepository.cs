using CGenius.Models;

namespace CGenius.Repository.Interface
{
    public interface IEmpregadoRepository
    {
        Task<IEnumerable<Empregado>> GetEmpregados();
        Task<Empregado> GetEmpregado(int empId);
        Task<Empregado> AddEmpregado(Empregado empregado);
        Task<Empregado> UpdateEmpregado(Empregado empregado);
        void DeleteEmpregado(int empId);
        Task<IEnumerable<Empregado>> GetEmpregadosPorDepartamento(int departamentoId);
    }
}
