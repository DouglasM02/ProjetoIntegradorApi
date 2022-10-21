using Microsoft.AspNetCore.Mvc;
using projetoIntegrador.Database;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models.Aluno;
using projetoIntegrador.Models.Sala;

namespace projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController:ControllerBase
    {
        private readonly ISalaService _service;
        private readonly Context _context;
        public SalaController(ISalaService service, Context context)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(SalaModel model)
        {
            try
            {
                var Sala = await _service.Create(model);
                return Ok(Sala);
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
                    return Ok("Sala deletada com sucesso");
                }
                return NotFound("Sala não encontrada");
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
                var Salas = await _service.GetAll();
                return Ok(Salas);
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
                var Sala = await _service.GetById(id);

                if (Sala == null)
                {
                    return NotFound("Sala não econtrada");
                }

                return Ok(Sala);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(SalaUpdateModel model)
        {
            try
            {
                var Sala = await _service.Update(model);
                if (Sala == null)
                {
                    return NotFound("Sala não encontrada");
                }

                return Ok(Sala);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
