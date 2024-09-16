using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CGenius.Models;
using CGenius.Repository.Interface;

namespace CGenius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScriptController : ControllerBase
    {
        private readonly IScriptRepository _scriptRepository;

        public ScriptController(IScriptRepository scriptRepository)
        {
            _scriptRepository = scriptRepository;
        }
        /// <summary>
        /// Buscar todos Scripts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Script>>> GetScripts()
        {
            var scripts = await _scriptRepository.GetScripts();
            return Ok(scripts);
        }
        /// <summary>
        /// Buscar Script
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Script>> GetScript(int id)
        {
            var script = await _scriptRepository.GetScript(id);
            if (script == null)
            {
                return NotFound();
            }
            return Ok(script);
        }
        /// <summary>
        /// Criar Script
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Script>> PostScript([FromBody] Script script)
        {
            var result = await _scriptRepository.AddScript(script);
            return CreatedAtAction(nameof(GetScript), new { id = result.IdScript }, result);
        }
        /// <summary>
        /// Update Script
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Script>> PutScript(int id, [FromBody] Script script)
        {
            if (id != script.IdScript)
            {
                return BadRequest();
            }

            var result = await _scriptRepository.UpdateScript(script);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        /// <summary>
        /// Delete Script
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScript(int id)
        {
            _scriptRepository.DeleteScript(id);
            return NoContent();
        }
    }
}
