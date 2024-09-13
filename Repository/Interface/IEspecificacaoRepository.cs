using System.Collections.Generic;
using System.Threading.Tasks;
using CGenius.Models;

namespace CGenius.Repository.Interface
{
    public interface IEspecificacaoRepository
    {
        Task<IEnumerable<Especificacao>> GetEspecificacoes();
        Task<Especificacao> GetEspecificacao(int idEspecificacao);
        Task<Especificacao> AddEspecificacao(Especificacao especificacao);
        Task<Especificacao> UpdateEspecificacao(Especificacao especificacao);
        void DeleteEspecificacao(int idEspecificacao);
    }
}