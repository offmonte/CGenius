using System.Collections.Generic;
using System.Threading.Tasks;
using FirstOne.Models;

namespace FirstOne.Repository.Interface
{
    public interface IPlanoRepository
    {
        Task<IEnumerable<Plano>> GetPlanos();
        Task<Plano> GetPlano(int idPlano);
        Task<Plano> AddPlano(Plano plano);
        Task<Plano> UpdatePlano(Plano plano);
        void DeletePlano(int idPlano);
    }
}