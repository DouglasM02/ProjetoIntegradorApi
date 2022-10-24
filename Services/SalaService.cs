using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models.Sala;

namespace projetoIntegrador.Services
{
    public class SalaService: ISalaService
    {
        private readonly ISalaRepository _repository;
        private readonly IProfessorService _professorService;
        public SalaService(ISalaRepository repository, IProfessorService professorService)
        {
            _repository = repository;
            _professorService = professorService;
        }

        public async Task<Sala> Create(SalaModel sala)
        {
            var Sala = new Entities.Sala
            {
                Codigo = sala.Codigo
            };
            try
            {
                var sal = await _repository.Create(Sala);
                if (sal == null)
                {
                    return null;
                }
                return sal;
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

        public Task<List<Sala>> GetAll()
        {
            var Salas = _repository.GetAll();
            return Salas;
        }

        public Task<Sala> GetById(int id)
        {
            var Sala = _repository.GetById(id);
            return Sala;
        }

        public async Task<Sala> Update(SalaUpdateModel sala)
        {
            var professor = await _professorService.GetById(sala.ProfessorId.GetValueOrDefault());

            if(professor == null)
            {
                sala.ProfessorId = null;
            }

            var Sala = await _repository.GetById(sala.Id);
            if (Sala == null)
            {
                return null;
            }

            Sala.Id = sala.Id;
            Sala.Codigo = sala.Codigo;
            Sala.ProfessorId = sala.ProfessorId;
            Sala.Professor = professor;
            var sal = await _repository.Update(Sala);
            return sal;
        }
    }
}
