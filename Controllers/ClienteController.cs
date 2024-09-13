using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CGenius.Models;
using CGenius.Repository.Interface;

namespace CGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                return Ok(await _clienteRepository.GetClientes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter clientes");
            }
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Cliente>> GetCliente(string cpf)
        {
            try
            {
                var result = await _clienteRepository.GetCliente(cpf);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter cliente");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AddCliente([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null) return BadRequest();

                var createCliente = await _clienteRepository.AddCliente(cliente);

                return CreatedAtAction(nameof(GetCliente), new { cpf = createCliente.CpfCliente }, createCliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar cliente");
            }
        }

        [HttpPut("{cpf}")]
        public async Task<ActionResult<Cliente>> UpdateCliente(string cpf, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteToUpdate = await _clienteRepository.GetCliente(cpf);

                if (clienteToUpdate == null) return NotFound($"Cliente com CPF {cpf} não encontrado");

                return await _clienteRepository.UpdateCliente(cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar cliente");
            }
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult> DeleteCliente(string cpf)
        {
            try
            {
                var clienteToDelete = await _clienteRepository.GetCliente(cpf);

                if (clienteToDelete == null) return NotFound($"Cliente com CPF {cpf} não encontrado");

                _clienteRepository.DeleteCliente(cpf);

                return Ok($"Cliente com CPF {cpf} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar cliente");
            }
        }
    }
}
