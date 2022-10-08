using Microsoft.AspNetCore.Mvc;
using projetoIntegrador.Database;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models;

namespace projetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController: ControllerBase
    {
        private readonly IAlunoService _service;
        private readonly Context _context;
        public AlunoController(IAlunoService service, Context context)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("Create")]
        public  async Task<IActionResult> Create(AlunoModel model)
        {
            try
            {
                var Aluno = await  _service.Create(model);
                return Ok(Aluno);
            }
            catch(Exception e)
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
                    return Ok("Aluno deletado com sucesso");
                }
                return NotFound("Aluno não encontrado");
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
                var Alunos = await _service.GetAll();
                return Ok(Alunos);
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
                var Aluno = await _service.GetById(id);

                if(Aluno == null)
                {
                    return NotFound("Aluno não econtrado");
                }

                return Ok(Aluno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AlunoUpdateModel model)
        {
            try
            {
                var Aluno = await _service.Update(model);
                if(Aluno == null)
                {
                    return NotFound("Aluno não encontrado");
                }

                return Ok(Aluno);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
