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
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendas()
        {
            try
            {
                return Ok(await _vendaRepository.GetVendas());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter vendas");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            try
            {
                var result = await _vendaRepository.GetVenda(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter venda");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Venda>> AddVenda([FromBody] Venda venda)
        {
            try
            {
                if (venda == null) return BadRequest();

                var createVenda = await _vendaRepository.AddVenda(venda);

                return CreatedAtAction(nameof(GetVenda), new { id = createVenda.IdVenda }, createVenda);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar venda");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Venda>> UpdateVenda(int id, [FromBody] Venda venda)
        {
            try
            {
                var vendaToUpdate = await _vendaRepository.GetVenda(id);

                if (vendaToUpdate == null) return NotFound($"Venda com ID {id} não encontrada");

                return await _vendaRepository.UpdateVenda(venda);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar venda");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteVenda(int id)
        {
            try
            {
                var vendaToDelete = await _vendaRepository.GetVenda(id);

                if (vendaToDelete == null) return NotFound($"Venda com ID {id} não encontrada");

                _vendaRepository.DeleteVenda(id);

                return Ok($"Venda com ID {id} deletada");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar venda");
            }
        }
    }
}
