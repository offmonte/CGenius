using System.Collections.Generic;
using System.Threading.Tasks;
using CGenius.Models;

namespace CGenius.Repository.Interface
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> GetVendas();
        Task<Venda> GetVenda(int idVenda);
        Task<Venda> AddVenda(Venda venda);
        Task<Venda> UpdateVenda(Venda venda);
        void DeleteVenda(int idVenda);
    }
}