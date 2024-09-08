using System.Collections.Generic;
using System.Threading.Tasks;
using FirstOne.Models;

namespace FirstOne.Repository.Interface
{
    public interface IAtendenteRepository
    {
        Task<IEnumerable<Atendente>> GetAtendentes();
        Task<Atendente> GetAtendente(string cpfAtendente);
        Task<Atendente> AddAtendente(Atendente atendente);
        Task<Atendente> UpdateAtendente(Atendente atendente);
        Task<Atendente> DeleteAtendente(string cpfAtendente);
    }
}
