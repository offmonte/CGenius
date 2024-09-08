using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstOne.Data;
using FirstOne.Models;
using FirstOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FirstOne.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly dbContext _dbContext;

        public ClienteRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetCliente(string cpfCliente)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(c => c.CpfCliente == cpfCliente);
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            var result = await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            var existingCliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.CpfCliente == cliente.CpfCliente);
            if (existingCliente != null)
            {
                existingCliente.NomeCliente = cliente.NomeCliente;
                existingCliente.DtNascimento = cliente.DtNascimento;
                existingCliente.Genero = cliente.Genero;
                existingCliente.Cep = cliente.Cep;
                existingCliente.Telefone = cliente.Telefone;
                existingCliente.Email = cliente.Email;
                existingCliente.PerfilCliente = cliente.PerfilCliente;
                existingCliente.IdScript = cliente.IdScript;

                await _dbContext.SaveChangesAsync();
                return existingCliente;
            }

            return null;
        }

        public async void DeleteCliente(string cpfCliente)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.CpfCliente == cpfCliente);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
