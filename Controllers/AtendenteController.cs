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
    public class AtendenteController : ControllerBase
    {
        private readonly IAtendenteRepository _atendenteRepository;

        public AtendenteController(IAtendenteRepository atendenteRepository)
        {
            _atendenteRepository = atendenteRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendente>>> GetAtendentes()
        {
            try
            {
                return Ok(await _atendenteRepository.GetAtendentes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter atendentes");
            }
        }
        /// <summary>
        /// Buscar Atendente
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Atendente>> GetAtendente(string cpf)
        {
            try
            {
                var result = await _atendenteRepository.GetAtendente(cpf);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter atendente");
            }
        }
        /// <summary>
        /// Criar Atendente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Atendente>> AddAtendente([FromBody] Atendente atendente)
        {
            try
            {
                if (atendente == null) return BadRequest();

                var createAtendente = await _atendenteRepository.AddAtendente(atendente);

                return CreatedAtAction(nameof(GetAtendente), new { cpf = createAtendente.CpfAtendente }, createAtendente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar atendente");
            }
        }
        /// <summary>
        /// Update Atendente
        /// </summary>
        /// <returns></returns>
        [HttpPut("{cpf}")]
        public async Task<ActionResult<Atendente>> UpdateAtendente(string cpf, [FromBody] Atendente atendente)
        {
            try
            {
                var atendenteToUpdate = await _atendenteRepository.GetAtendente(cpf);

                if (atendenteToUpdate == null) return NotFound($"Atendente com CPF {cpf} não encontrado");

                return await _atendenteRepository.UpdateAtendente(atendente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar atendente");
            }
        }
        /// <summary>
        /// Deletar Atendente
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{cpf}")]
        public async Task<ActionResult> DeleteAtendente(string cpf)
        {
            try
            {
                var atendenteToDelete = await _atendenteRepository.GetAtendente(cpf);

                if (atendenteToDelete == null) return NotFound($"Atendente com CPF {cpf} não encontrado");

                _atendenteRepository.DeleteAtendente(cpf);

                return Ok($"Atendente com CPF {cpf} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar atendente");
            }
        }
    }
}
