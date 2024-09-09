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
    public class EspecificacaoController : ControllerBase
    {
        private readonly IEspecificacaoRepository _especificacaoRepository;

        public EspecificacaoController(IEspecificacaoRepository especificacaoRepository)
        {
            _especificacaoRepository = especificacaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especificacao>>> GetEspecificacoes()
        {
            try
            {
                return Ok(await _especificacaoRepository.GetEspecificacoes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter especificações");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Especificacao>> GetEspecificacao(int id)
        {
            try
            {
                var result = await _especificacaoRepository.GetEspecificacao(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter especificação");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Especificacao>> AddEspecificacao([FromBody] Especificacao especificacao)
        {
            try
            {
                if (especificacao == null) return BadRequest();

                var createEspecificacao = await _especificacaoRepository.AddEspecificacao(especificacao);

                return CreatedAtAction(nameof(GetEspecificacao), new { id = createEspecificacao.IdEspecificacao }, createEspecificacao);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar especificação");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Especificacao>> UpdateEspecificacao(int id, [FromBody] Especificacao especificacao)
        {
            try
            {
                var especificacaoToUpdate = await _especificacaoRepository.GetEspecificacao(id);

                if (especificacaoToUpdate == null) return NotFound($"Especificação com ID {id} não encontrada");

                return await _especificacaoRepository.UpdateEspecificacao(especificacao);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar especificação");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEspecificacao(int id)
        {
            try
            {
                var especificacaoToDelete = await _especificacaoRepository.GetEspecificacao(id);

                if (especificacaoToDelete == null) return NotFound($"Especificação com ID {id} não encontrada");

                await _especificacaoRepository.DeleteEspecificacao(id);

                return Ok($"Especificação com ID {id} deletada");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar especificação");
            }
        }
    }
}
