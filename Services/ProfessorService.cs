using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models.Professor;

namespace projetoIntegrador.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;
        public ProfessorService(IProfessorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Professor> Create(ProfessorModel professor)
        {
            var Professor = new Professor
            {
                
                Nome = professor.Nome,
                CPF = professor.CPF,
                DataNascimento = professor.DataNascimento.ToUniversalTime(),
                Graduacao = professor.Graduacao
            };
            try
            {
                var prof = await _repository.Create(Professor);
                if (prof == null)
                {
                    return null;
                }
                return prof;
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

        public Task<List<Professor>> GetAll()
        {
            var Alunos = _repository.GetAll();
            return Alunos;
        }

        public Task<Professor> GetById(int id)
        {
            var Aluno = _repository.GetById(id);
            return Aluno;
        }

        public async Task<Professor> Update(ProfessorUpdateModel professor)
        {
            var Professor = await _repository.GetById(professor.Id);
            if (Professor == null)
            {
                return null;
            }

            Professor.Id = professor.Id;
            Professor.Nome = professor.Nome;
            Professor.CPF = professor.CPF;
            Professor.DataNascimento = professor.DataNascimento.ToUniversalTime();
            Professor.Graduacao = professor.Graduacao;
            var prof = await _repository.Update(Professor);
            return prof;
        }
    }
}
