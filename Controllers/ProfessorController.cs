using Microsoft.AspNetCore.Mvc;
using projetoIntegrador.Database;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models.Aluno;
using projetoIntegrador.Models.Professor;

namespace projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController: ControllerBase
    {
        private readonly IProfessorService _service;
        private readonly Context _context;

        public ProfessorController(IProfessorService service, Context context)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProfessorModel model)
        {
            try
            {
                var Professor = await _service.Create(model);
                return Ok(Professor);
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
                    return Ok("Professor deletado com sucesso");
                }
                return NotFound("Professor não encontrado");
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
                var Professores = await _service.GetAll();
                return Ok(Professores);
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
                var Professor = await _service.GetById(id);

                if (Professor == null)
                {
                    return NotFound("Professor não econtrado");
                }

                return Ok(Professor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProfessorUpdateModel model)
        {
            try
            {
                var Professor = await _service.Update(model);
                if (Professor == null)
                {
                    return NotFound("Professor não encontrado");
                }

                return Ok(Professor);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
