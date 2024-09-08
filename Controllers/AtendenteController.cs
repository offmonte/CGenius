using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstOne.Models;
using FirstOne.Repository.Interface;

namespace FirstOne.Controllers
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
            var atendentes = await _atendenteRepository.GetAtendentes();
            return Ok(atendentes);
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Atendente>> GetAtendente(string cpf)
        {
            var atendente = await _atendenteRepository.GetAtendente(cpf);
            if (atendente == null)
            {
                return NotFound();
            }
            return Ok(atendente);
        }

        [HttpPost]
        public async Task<ActionResult<Atendente>> PostAtendente([FromBody] Atendente atendente)
        {
            var result = await _atendenteRepository.AddAtendente(atendente);
            return CreatedAtAction(nameof(GetAtendente), new { cpf = result.CpfAtendente }, result);
        }

        [HttpPut("{cpf}")]
        public async Task<ActionResult<Atendente>> PutAtendente(string cpf, [FromBody] Atendente atendente)
        {
            if (cpf != atendente.CpfAtendente)
            {
                return BadRequest();
            }

            var result = await _atendenteRepository.UpdateAtendente(atendente);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeleteAtendente(string cpf)
        {
            await _atendenteRepository.DeleteAtendente(cpf);
            return NoContent();
        }
    }
}
