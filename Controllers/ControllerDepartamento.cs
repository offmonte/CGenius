using FirstOne.Models;
using FirstOne.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentosController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartamentos()
        {
            try
            {
                return Ok(await _departamentoRepository.GetDepartamentos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter departamentos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            try
            {
                var result = await _departamentoRepository.GetDepartamento(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter departamento");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> AddDepartamento([FromBody] Departamento departamento)
        {
            try
            {
                if (departamento == null) return BadRequest();

                var createDept = await _departamentoRepository.AddDepartamento(departamento);

                return CreatedAtAction(nameof(GetDepartamento),
                    new { id = createDept.DepartamentoId }, createDept);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar departamento");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Departamento>> UpdateDepartamento([FromBody] Departamento departamento)
        {
            try
            {
                var deptToUpdate = await _departamentoRepository.GetDepartamento(departamento.DepartamentoId);
                if (deptToUpdate == null) return NotFound($"Departamento com id {departamento.DepartamentoId} não encontrado");

                return await _departamentoRepository.UpdateDepartamento(departamento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar departamento");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            try
            {
                var deptToDelete = await _departamentoRepository.GetDepartamento(id);
                if (deptToDelete == null) return NotFound($"Departamento com id {id} não encontrado");

                await _departamentoRepository.DeleteDepartamento(id);

                return Ok($"Departamento com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar departamento");
            }
        }
    }
}