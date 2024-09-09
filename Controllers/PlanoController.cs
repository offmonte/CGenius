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
    public class PlanoController : ControllerBase
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoController(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plano>>> GetPlanos()
        {
            try
            {
                return Ok(await _planoRepository.GetPlanos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter planos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Plano>> GetPlano(int id)
        {
            try
            {
                var result = await _planoRepository.GetPlano(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter plano");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Plano>> AddPlano([FromBody] Plano plano)
        {
            try
            {
                if (plano == null) return BadRequest();

                var createPlano = await _planoRepository.AddPlano(plano);

                return CreatedAtAction(nameof(GetPlano), new { id = createPlano.IdPlano }, createPlano);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar plano");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Plano>> UpdatePlano(int id, [FromBody] Plano plano)
        {
            try
            {
                var planoToUpdate = await _planoRepository.GetPlano(id);

                if (planoToUpdate == null) return NotFound($"Plano com ID {id} não encontrado");

                return await _planoRepository.UpdatePlano(plano);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar plano");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePlano(int id)
        {
            try
            {
                var planoToDelete = await _planoRepository.GetPlano(id);

                if (planoToDelete == null) return NotFound($"Plano com ID {id} não encontrado");

                await _planoRepository.DeletePlano(id);

                return Ok($"Plano com ID {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar plano");
            }
        }
    }
}
