using System.Collections.Generic;
using System.Threading.Tasks;
using CGenius.Models;

namespace CGenius.Repository.Interface
{
    public interface IPlanoRepository
    {
        Task<IEnumerable<Plano>> GetPlanos();
        Task<Plano> GetPlano(int idPlano);
        Task<Plano> AddPlano(Plano plano);
        Task<Plano> UpdatePlano(Plano plano);
        Task DeletePlano(int idPlano);
    }
}