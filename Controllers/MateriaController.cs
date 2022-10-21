using Microsoft.AspNetCore.Mvc;
using projetoIntegrador.Database;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models.Aluno;
using projetoIntegrador.Models.Materia;

namespace projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController: ControllerBase
    {
        private readonly IMateriaService _service;
        private readonly Context _context;
        public MateriaController(IMateriaService service, Context context)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(MateriaModel model)
        {
            try
            {
                var Materia = await _service.Create(model);
                return Ok(Materia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.Delete(id);
                if (response)
                {
                    return Ok("Materia deletada com sucesso");
                }
                return NotFound("Materia não encontrada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Materias = await _service.GetAll();
                return Ok(Materias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Materia = await _service.GetById(id);

                if (Materia == null)
                {
                    return NotFound("Materia não econtrada");
                }

                return Ok(Materia);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(MateriaUpdateModel model)
        {
            try
            {
                var Materia = await _service.Update(model);
                if (Materia == null)
                {
                    return NotFound("Materia não encontrada");
                }

                return Ok(Materia);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
