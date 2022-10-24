using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Migrations;
using projetoIntegrador.Models.Materia;

namespace projetoIntegrador.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _repository;
        private readonly IProfessorService _professorService;
        public MateriaService(IMateriaRepository repository, IProfessorService professorService)
        {
            _repository = repository;
            _professorService = professorService;
        }
        public async Task<Entities.Materia> Create(MateriaModel materia)
        {
            var Materia = new Entities.Materia
            {
                Nome = materia.Nome
            };
            try
            {
                var mat = await _repository.Create(Materia);
                if (mat == null)
                {
                    return null;
                }
                return mat;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if (!result)
            {
                return false;
            }

            return true;
        }

        public Task<List<Entities.Materia>> GetAll()
        {
            var Materias = _repository.GetAll();
            return Materias;
        }

        public Task<Entities.Materia> GetById(int id)
        {
            var Materia = _repository.GetById(id);
            return Materia;
        }

        public async Task<Entities.Materia> Update(MateriaUpdateModel materia)
        {
            var professor = await _professorService.GetById(materia.ProfessorId.GetValueOrDefault());

            if(professor == null)
            {
                materia.ProfessorId = null;
            }

            var Materia = await _repository.GetById(materia.Id);
            if (Materia == null)
            {
                return null;
            }

            Materia.Id = materia.Id;
            Materia.Nome = materia.Nome;
            Materia.ProfessorId = materia.ProfessorId;
            Materia.Professor = professor;
            var mat = await _repository.Update(Materia);
            return mat;
        }
    }
}
